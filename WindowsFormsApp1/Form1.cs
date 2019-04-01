using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using StackExchange.Redis;
using XA_SESSIONLib;
using XA_DATASETLib;
using Telegram.Bot;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Telegram
        static ITelegramBotClient botClient;
        // MongoDB
        MongoClient client = null;
        IMongoDatabase db = null;
        // Redis
        ConnectionMultiplexer redis = null;
        IDatabase database = null;
        // 세션 및 쿼리클라스 글로벌 변수 생성
        XASessionClass session = new XASessionClass();
        XAQueryClass query = new XAQueryClass();
        XAQueryClass order = new XAQueryClass();
        // 쓰래드 생성
        // 가격정보 쓰래드
        private ThreadStart _information_ts = null;
        private Thread _information = null;
        // 거래 쓰래드
        private ThreadStart _Worker = null;
        private Thread _Working = null;
        // 접속 URL 셋업
        private string ConnectURL;
        private string OrderOption;

        public Form1()
        {
            InitializeComponent();
            setupDB();
            setupRedis();
            session._IXASessionEvents_Event_Login += Session__IXASessionEvents_Event_Login;
            session._IXASessionEvents_Event_Logout += Session__IXASessionEvents_Event_Logout;
            query.ReceiveData += Query_ReceiveData;
            query.ReceiveMessage += Query_ReceiveMessage;
            session.Disconnect += Session_Disconnect;
        }

        private void Query_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            // 쿼리결과 수신
            LogBox.Items.Add("[" + nMessageCode + "] " + szMessage);
        }

        // 거래 기록함수
        public void writeOrder(int orderType, long orderPrice, int orderQty, string orderNo, string jongmokCode, string jongmokNM)
        {
            // MongoDB Collection 할당
            var collection = db.GetCollection<BsonDocument>("TB_ORD_LST");
            // orderType - 주문 속성. 1: 매도, 2: 매수
            // orderPrice - 주문가 (주문 당시 시장가)
            // orderQty - 주문 갯수
            // orderNo - 주문번호
            // jongmokCode - 종목코드
            // jongmokNM - 종목명
            DateTime date = DateTime.Now;
            double totalOrderPrice = 0;
            string ORDERCOMPLETED;
            if (orderType == 2)
            {
                // 매수처리 하는 경우에는 수수료 0.015% (0.00015)를 곱하여 계산
                totalOrderPrice = Math.Truncate((orderPrice * orderQty) + ((orderPrice * orderQty) * 0.00015));
            }
            else if (orderType == 1)
            {
                // 매도처리 하는 경우에는 수수료 0.015% 및 세금 0.3%를 곱하여 계산
                totalOrderPrice = Math.Truncate((orderPrice * orderQty) + ((orderPrice * orderQty) * 0.00315));
            }
            else if (orderType == 0)
            {
                // 취소처리 하는 경우에는 수수료가 없음.
                totalOrderPrice = orderPrice * orderQty;
            }
            if (orderNo == "0")
            {
                // 미채결상태
                ORDERCOMPLETED = "N";
            }
            else
            {
                // 채결상태
                ORDERCOMPLETED = "Y";
            }
            var document = new BsonDocument
            {
                {"REF_DT", date.ToString("MM-dd-yyy") },
                {"JONGMOK_CD", jongmokCode },
                {"JONGMOK_NM", jongmokNM },
                {"ORD_GB", orderType },
                {"ORD_NO", orderNo },
                {"ORD_COMPLETED", ORDERCOMPLETED },
                {"ORD_PRICE", orderPrice },
                {"ORD_STOCK_CNT", orderQty},
                {"ORD_AMT", totalOrderPrice},
                {"ORD_DTM", date.ToString("MM-dd-yyy")},
                {"ORD_TS", date.ToString("H:mm") }
            };
            collection.InsertOne(document);
            LogBox.Items.Add("주문종목 기록완료!");
        }

        public void RefreshOrderState()
        {
            // 체결정보 수신
        }

        private void Query_ReceiveData(string szTrCode)
        {
            if (szTrCode.Length > 0)
            {
                if (szTrCode == "CSPAT00600")
                {
                    // 거래관련 정보인 경우 여기에서 거래처리
                    string orderNo = query.GetFieldData("CSPAT00600OutBlock2", "OrdNo", 0);
                    database.StringSet("TRDataState", szTrCode);  // 거래항목
                    database.StringSet("RecentOrderNo", orderNo); // 주문번호 셋업
                    LogBox.Items.Add("Data In: " + szTrCode);
                }
                else
                {
                    // 그 외는 여기에서 처리
                    database.StringSet("TRDataState", szTrCode);
                    LogBox.Items.Add("Data In: " + szTrCode);
                }
            }
            else
            {
                LogBox.Items.Add("데이터 전송 에러!");
                LogBox.Items.Add("TR 데이터 코드: " + szTrCode);
                database.StringSet("TRDataState", "ERR");
            }
        }

        public void setupDB()
        {
            try
            {
                client = new MongoClient();
                db = client.GetDatabase("trading");
                LogBox.Items.Add("몽고DB 셋업 완료!");
            } catch (Exception ex)
            {
                LogBox.Items.Add("몽고 DB 셋업 에러!");
                LogBox.Items.Add(ex.Message);
            }
        }

        public void setupRedis()
        {
            try
            {
                redis = ConnectionMultiplexer.Connect("localhost");
                database = redis.GetDatabase();
                database.StringSet("TRDataState", 0);       // 최근 조회 데이터
                database.StringSet("loginState", 0);        // 로그인 상태값
                database.StringSet("RecentOrderNo", 0);     // 최근 주문번호
                database.StringSet("RecentOrderState", 0);  // 최근 주문의 State 값
                LogBox.Items.Add("Redis 셋업 완료!");
            } catch (Exception ex)
            {
                LogBox.Items.Add("Redis 셋업 에러!");
                LogBox.Items.Add(ex.Message);
            }
        }

        public void add_jongmok()
        {
            string jongmok_code = jongmokCode.Text;   // 종목코드
            int qty = Decimal.ToInt32(stockQty.Value);
            string jongmok_nm;                        // 주식이름
            long price;                               // 주식가격
            int price_hoga_t1;                        // 매수호가1
            int price_hoga_t2;                        // 매수호가2
            int price_sehoga_t1;                      // 매도호가1
            int price_sehoga_t2;                      // 매도호가2
            string BnsTpCode = "";

            if (OrderOption == "매도")
            {
                BnsTpCode = "1";
                
            }
            else if (OrderOption == "매수")
            {
                BnsTpCode = "2";
            }
            else
            {
                
            }

            // 종목명 가져오기
            query.ResFileName = "Res/t1101.res";
            query.SetFieldData("t1101InBlock", "shcode", 0, jongmok_code);
            int rQstate = query.Request(false);
            if (rQstate < 0)
            {
                LogBox.Items.Add("전송에러!");
                LogBox.Items.Add("에러코드: "+rQstate);
            }
            else
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (database.StringGet("TRDataState") == "t1101")
                    {
                        jongmok_nm = query.GetFieldData("t1101OutBlock", "hname", 0);                    // 종목이름
                        price = long.Parse(query.GetFieldData("t1101OutBlock", "price", 0));             // 시장가
                        price_hoga_t1 = int.Parse(query.GetFieldData("t1101OutBlock", "bidho1", 0));     // 매수호가1
                        price_hoga_t2 = int.Parse(query.GetFieldData("t1101OutBlock", "bidho2", 0));     // 매수호가2
                        price_sehoga_t1 = int.Parse(query.GetFieldData("t1101OutBlock", "offerho1", 0)); // 매도호가1
                        price_sehoga_t2 = int.Parse(query.GetFieldData("t1101OutBlock", "offerho2", 0)); // 매도호가2 
                        if (jongmok_nm.Length > 0)
                        {
                            // 계좌번호 있는지 검사
                            string accountCode = cmbAccount.Items[0].ToString();
                            if (accountCode.Length > 0)
                            {
                                // 계좌번호가 있는 것으로 확인한 후 주문 진행
                                query.ResFileName = "Res/CSPAT00600.res";
                                query.SetFieldData("CSPAT00600InBlock1", "AcntNo", 0, accountCode);        // 계좌번호
                                query.SetFieldData("CSPAT00600InBlock1", "InptPwd", 0, txtPassword.Text);  // 입력비밀번호
                                query.SetFieldData("CSPAT00600InBlock1", "IsuNo", 0, jongmokCode.Text);    // 종목코드
                                query.SetFieldData("CSPAT00600InBlock1", "OrdQty", 0, qty.ToString());     // 주문수량
                                query.SetFieldData("CSPAT00600InBlock1", "OrdPrc", 0, price.ToString());   // 주문가
                                query.SetFieldData("CSPAT00600InBlock1", "BnsTpCode", 0, BnsTpCode);       // 매매구분
                                query.SetFieldData("CSPAT00600InBlock1", "OrdprcPtnCode", 0, "00");        // 호가유형구분 (00: 지정가, 03: 시장가)
                                query.SetFieldData("CSPAT00600InBlock1", "MgntrnCode", 0, "000");          // 신용거래구분 - 000
                                query.SetFieldData("CSPAT00600InBlock1", "LoanDt", 0, "");                 // 대출일 - 사용하지 않음
                                query.SetFieldData("CSPAT00600InBlock1", "OrdCndiTpCode", 0, "0");         // 주문조건구분 - 0
                                int joomonState = query.Request(false); // 주문요청
                                if (joomonState < 0)
                                {
                                    LogBox.Items.Add("전송실패!");
                                    LogBox.Items.Add("에러코드: " + joomonState);
                                    break;
                                }
                                else
                                {
                                    // 주문결과 전송될때까지 0.5 초 기다림
                                    LogBox.Items.Add("주문 전송완료!");
                                    Thread.Sleep(500);
                                    if (database.StringGet("TRDataState") == "CSPAT00600")
                                    {
                                        // 주문상태 가져오기
                                        if (database.StringGet("RecentOrderState") != "true")
                                        {
                                            // 주문에러로 기록하지 않음.
                                        }
                                        else
                                        {
                                            LogBox.Items.Add("주문이 정상적으로 완료되었습니다");
                                            LogBox.Items.Add("주문번호: " + database.StringGet("RecentOrderNo"));
                                            // 함수에 거래항목 기록
                                            writeOrder(int.Parse(BnsTpCode), price, qty, database.StringGet("RecentOrderNo"), jongmok_code, jongmok_nm);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        // 주문접수 안된 경우
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // 계좌번호 오류
                                break;
                            }
                        }
                        else
                        {
                            // 종목코드 오류.
                            break;
                        }
                    }
                    else
                    {

                    }
                }
                _information.Abort();
            }
            
            
        }

        private void Session__IXASessionEvents_Event_Login(string szCode, string szMsg)
        {
            // 로그인처리 이벤트
            // szCode가 "0000"인 경우 정상으로 처리, 그 외는 모두 에러로 처리
            if (szCode == "0000")
            {
                // 로그인 성공, 비밀번호 잠금처리
                txtPassword.Enabled = false;
                if (txtPasswordIn.Enabled)
                {
                    txtPasswordIn.Enabled = false;
                }
                else
                {
                    // pass
                }
                // 로그인 성공하면 계좌정보 가져오기
                for (int i = 0; i < session.GetAccountListCount(); i++)
                {
                    // 계좌번호 가져와서 리스트에 추가
                    string STKAccount = session.GetAccountList(i);
                    if (STKAccount.Length > 0)
                    {
                        LogBox.Items.Add(STKAccount);
                        cmbAccount.Items.Clear();
                        cmbAccount.Items.Add(STKAccount);
                    }
                }
                // isLogin = true;
                database.StringSet("loginState", "true");
            }
            else
            {
                // 로그인 에러.
                LogBox.Items.Add("로그인 에러!");
                LogBox.Items.Add("[" + szCode + "] " + szMsg);
                database.StringSet("loginState", "false");
            }
        }

        private void Session__IXASessionEvents_Event_Logout()
        {
            // 로그아웃처리 이벤트
        }

        private void Session_Disconnect()
        {
            // 세션 접속 끊김 이벤트
            LogBox.Items.Add("서버와의 접속이 끊겼습니다.");
            // 텔레그램 메시지 송신
            
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            bool isConnected = session.IsConnected();
            if (isConnected == false)
            {
                // 접속 URL 셋업
                if (chkPaperTrading.Checked)
                {
                    // 모의투자인 경우 접속하는 URL이 다름
                    ConnectURL = "demo.etrade.co.kr";
                    // session.ConnectServer("demo.ebestsec.co.kr", 20001);
                }
                else
                {
                    // 실거래는 여기로 접속되도록 처리
                    ConnectURL = "hts.etrade.co.kr";
                    // session.ConnectServer("hts.ebestsec.co.kr", 20001);
                }
                // 접속요청
                bool bSession = session.ConnectServer(ConnectURL, 20001);
                if (bSession == true)
                {
                    // 연결 정상, 로그인 요청
                    // 인풋값중 맨 마지막 boolean 값은 공인인증서 에러 표시위한 옵션.
                    if (session.Login(txtID.Text, txtPassword.Text, txtPasswordIn.Text, 0, false))
                    {
                        LogBox.Items.Add("로그인 서버전송 완료");
                    }
                    else
                    {
                        // 로그인 요청안됨. 에러
                        LogBox.Items.Add("로그인 서버전송에 실패하였습니다.");
                    }
                }
                else
                {
                    // 연결 비정상처리
                    int nErrCode = session.GetLastError();
                    string strErrMsg = session.GetErrorMessage(nErrCode);
                    // 연결 안됨 처리
                    LogBox.Items.Add("연결 에러");
                    LogBox.Items.Add("에러코드: [" + nErrCode + "] ");
                    LogBox.Items.Add(strErrMsg);
                }
            }
            else
            {
                // 연결처리가 된 상태이므로 패스
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            // 종료처리
            Application.Exit();
        }

        private void startAutoTrding_Click(object sender, EventArgs e)
        {
            // 자동매매 시작 반드시 쓰래드 사용할 것.
        }

        private void stopAutoTrading_Click(object sender, EventArgs e)
        {
            // 자동매매 중지
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SearchjongMok_Click(object sender, EventArgs e)
        {
            // 가격정보 가져오는 쓰레드
            _information_ts = new ThreadStart(add_jongmok);
            _information = new Thread(_information_ts);
            _information.Start();
        }

        private void chkPaperTrading_CheckedChanged(object sender, EventArgs e)
        {
            // 모의투자 체크 변경될 경우 공인인증 입력 잠그기
            if (chkPaperTrading.Checked == true)
            {
                txtPasswordIn.Enabled = false;
            }
            else
            {
                txtPasswordIn.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                OrderOption = ((RadioButton)sender).Text;
            }
        }
    }
}
