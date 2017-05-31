using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSurvey.Models;

namespace AppSurvey.Data
{
    public class AppSurveyDbInitializer
    {
        public static void Initialize(AppSurveyDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Questions.Any())
            {
                return;   // DB has been seeded
            }

            var questions = new Question[]
            {
                new Question{ QuestionID = 1,  Index = 1,  Description = "您目前的工作狀況為何(不包括留職停薪,育嬰假,請依主要薪水來源作答)?" },
                new Question{ QuestionID = 2,  Index = 1,  Description = "請問您任職的機構性質是:" },
                new Question{ QuestionID = 3,  Index = 1,  Description = "請問您一週工作時數約幾小時?" },
                new Question{ QuestionID = 4,  Index = 1,  Description = "請問您任職的機構性質是(若同時有多份 Part Time 工作, 請以主要工作時數較長者作答):" },

                new Question{ QuestionID = 5,  Index = 2,  Description = "您現在工作職業類型為何?" },
                new Question{ QuestionID = 6,  Index = 3,  Description = "您畢業後花了多久時間找到第一份工作? (若為創業者,請填答畢業後至創業時間; 自由工作者,則以第一份穩定工作時間為主)" },
                new Question{ QuestionID = 7,  Index = 4,  Description = "您現在工作平均每月收入為何?" },
                new Question{ QuestionID = 8,  Index = 5,  Description = "請問您現在主要的工作所在地點為何?" },
                new Question{ QuestionID = 9,  Index = 5,  Description = "境內地區縣市:" },
                new Question{ QuestionID = 10, Index = 5,  Description = "境外地區國家: (請在下欄請填地區或國家)" },
                new Question{ QuestionID = 11, Index = 6,  Description = "您目前未就業的原因為何?" },
                new Question{ QuestionID = 12, Index = 6,  Description = "何種類別考試?" },
                new Question{ QuestionID = 13, Index = 6,  Description = "到現在還在尋找工作的最大可能原因為何?" },
                new Question{ QuestionID = 14, Index = 6,  Description = "目前已花了多久時間找工作?" },

                new Question{ QuestionID = 15, Index = 7,  Description = "您目前所具備的專業能力與工作所要求的相符程度為何?" },
                new Question{ QuestionID = 16, Index = 8,  Description = "您目前的工作內容,是否需要具備專業證照?" },
                new Question{ QuestionID = 17, Index = 9,  Description = "您對目前工作的整體滿意度為何?" },
                new Question{ QuestionID = 18, Index = 10, Description = "您目前的工作內容與原就讀系,所,學位學程之專業訓練課程,其相符程度為何?" },
                new Question{ QuestionID = 19, Index = 11, Description = "您在學期間以下哪些'學習經驗'對於現在工作有所幫助? (可複選,至多三項)" },

                new Question{ QuestionID = 20, Index = 12, Description = "您是否有為了工作或自我生涯發展從事進修或考試,提升自我專業能力?" },
                new Question{ QuestionID = 21, Index = 12, Description = "進修類別:" },
                new Question{ QuestionID = 22, Index = 12, Description = "考試或證照類別:" },
                new Question{ QuestionID = 23, Index = 13, Description = "您常參與學校職涯活動或就業服務的幫助嗎?" },
                new Question{ QuestionID = 24, Index = 13, Description = "您最常參與過學校哪些職涯活動或就業服務的幫助? (可複選,至多三項)" }
            };

            foreach (Question q in questions)
            {
                context.Questions.Add(q);
            }
            context.SaveChanges();

            var options = new Option[]
            {
                new Option { QuestionID = 1, Rank = 1,  Code = "Z1 2 A", Category = "全職工作" },
                new Option { QuestionID = 1, Rank = 2,  Code = "Z2 3 A", Category = "部分工時" },
                new Option { QuestionID = 1, Rank = 3,  Code = "A16 23 A", Category = "家管/料理家務者" },
                new Option { QuestionID = 1, Rank = 4,  Code = "A17 11 A", Category = "目前非就業中" },

                new Option { QuestionID = 2, Rank = 1,  Code = "A1 5 A", Category = "企業 (包括民營企業或國營企業 ... 等)" },
                new Option { QuestionID = 2, Rank = 2,  Code = "A2 5 A", Category = "政府部門 (含職業軍人)" },
                new Option { QuestionID = 2, Rank = 3,  Code = "A3 5 A", Category = "學校 (包括公立及私立大學,高中,高職,國中小 ... 等)" },
                new Option { QuestionID = 2, Rank = 4,  Code = "A4 5 A", Category = "非營利機構" },
                new Option { QuestionID = 2, Rank = 5,  Code = "A5 5 A", Category = "創業" },
                new Option { QuestionID = 2, Rank = 6,  Code = "A6 5 A", Category = "自由工作者 (以接案維生或個人服務,例如撰稿人 ...)" },
                new Option { QuestionID = 2, Rank = 51, Code = "A7 5 Q", Category = "其他 (請填寫答案)" },

                new Option { QuestionID = 3, Rank = 51, Code = "A8 4 Q", Category = "請點選並填寫時數" },

                new Option { QuestionID = 4, Rank = 1,  Code = "A9 5 A", Category = "企業 (包括民營企業或國營企業 ... 等)" },
                new Option { QuestionID = 4, Rank = 2,  Code = "A10 5 A", Category = "政府部門 (含職業軍人)" },
                new Option { QuestionID = 4, Rank = 3,  Code = "A11 5 A", Category = "學校 (包括公立及私立大學,高中,高職,國中小 ... 等)" },
                new Option { QuestionID = 4, Rank = 4,  Code = "A12 5 A", Category = "非營利機構" },
                new Option { QuestionID = 4, Rank = 5,  Code = "A13 5 A", Category = "創業" },
                new Option { QuestionID = 4, Rank = 6,  Code = "A14 5 A", Category = "自由工作者 (以接案維生或個人服務,例如幫忙排隊 ...)" },
                new Option { QuestionID = 4, Rank = 51, Code = "A15 5 Q", Category = "其他 (請填寫答案)" },

                new Option { QuestionID = 5, Rank = 1,  Code = "B1 6 A", Category = "建築營造類", Description = "針對建築物" },
                new Option { QuestionID = 5, Rank = 2,  Code = "B2 6 A", Category = "製造類", Description = "規劃,執行" },
                new Option { QuestionID = 5, Rank = 3,  Code = "B3 6 A", Category = "科學,技術,工程,數學類", Description = "規劃,管理"  },
                new Option { QuestionID = 5, Rank = 4,  Code = "B4 6 A", Category = "物流運輸類", Description = "將物料或產品"  },
                new Option { QuestionID = 5, Rank = 5,  Code = "B5 6 A", Category = "天然資源,食品與農業類", Description = "凡在農,林,漁,牧"  },
                new Option { QuestionID = 5, Rank = 6,  Code = "B6 6 A", Category = "醫療保健類", Description = "從事人類所患"  },
                new Option { QuestionID = 5, Rank = 7,  Code = "B7 6 A", Category = "藝文與影音傳播類", Description = "規劃設計"  },
                new Option { QuestionID = 5, Rank = 8,  Code = "B8 6 A", Category = "資訊科技類", Description = "從事網際網路"  },
                new Option { QuestionID = 5, Rank = 9,  Code = "B9 6 A", Category = "金融財務類", Description = "凡在金融"  },
                new Option { QuestionID = 5, Rank = 10, Code = "B10 6 A", Category = "企業經營管理類", Description = "利用規劃,組織"  },
                new Option { QuestionID = 5, Rank = 11, Code = "B11 6 A", Category = "行銷與銷售類", Description = "企業或組織內"  },
                new Option { QuestionID = 5, Rank = 12, Code = "B12 6 A", Category = "政府公共事務類", Description = "執行政府功能"  },
                new Option { QuestionID = 5, Rank = 13, Code = "B13 6 A", Category = "教育與訓練類", Description = "評估內外在"  },
                new Option { QuestionID = 5, Rank = 14, Code = "B14 6 A", Category = "個人及社會服務類", Description = "針對社會,家庭"  },
                new Option { QuestionID = 5, Rank = 15, Code = "B15 6 A", Category = "休閒與觀光旅遊類", Description = "從事旅遊及休閒"  },
                new Option { QuestionID = 5, Rank = 16, Code = "B16 6 A", Category = "司法,法律與公共安全類", Description = "從事與法律"  },

                new Option { QuestionID = 6, Rank = 1,  Code = "C1 7 A", Category = "約一個月內" },
                new Option { QuestionID = 6, Rank = 2,  Code = "C2 7 A", Category = "約一個月以上至二個月內" },
                new Option { QuestionID = 6, Rank = 3,  Code = "C3 7 A", Category = "約二個月以上至三個月內" },
                new Option { QuestionID = 6, Rank = 4,  Code = "C4 7 A", Category = "約三個月以上至四個月內" },
                new Option { QuestionID = 6, Rank = 5,  Code = "C5 7 A", Category = "約四個月以上至六個月內" },
                new Option { QuestionID = 6, Rank = 51, Code = "C6 7 Q", Category = "約六個月以上 (請填寫月數)" },
                new Option { QuestionID = 6, Rank = 52, Code = "C7 7 A", Category = "畢業前已有專職工作" },

                new Option { QuestionID = 7, Rank = 1,  Code = "D1 8 A", Category = "約新台幣 20,000 以下" },
                new Option { QuestionID = 7, Rank = 2,  Code = "D2 8 A", Category = "約新台幣 20,001 元至 22,000 元" },
                new Option { QuestionID = 7, Rank = 3,  Code = "D3 8 A", Category = "約新台幣 22,000 元至 25,000 元" },
                new Option { QuestionID = 7, Rank = 4,  Code = "D4 8 A", Category = "約新台幣 25,001 元至 28,000 元" },
                new Option { QuestionID = 7, Rank = 5,  Code = "D5 8 A", Category = "約新台幣 28,001 元至 31,000 元" },
                new Option { QuestionID = 7, Rank = 6,  Code = "D6 8 A", Category = "約新台幣 31,001 元至 34,000 元" },
                new Option { QuestionID = 7, Rank = 7,  Code = "D7 8 A", Category = "約新台幣 34,001 元至 37,000 元" },
                new Option { QuestionID = 7, Rank = 8,  Code = "D8 8 A", Category = "約新台幣 37,001 元至 40,000 元" },
                new Option { QuestionID = 7, Rank = 9,  Code = "D9 8 A", Category = "約新台幣 40,001 元至 45,000 元" },
                new Option { QuestionID = 7, Rank = 10, Code = "D10 8 A", Category = "約新台幣 45,001 元至 50,000 元" },
                new Option { QuestionID = 7, Rank = 11, Code = "D11 8 A", Category = "約新台幣 50,001 元至 55,000 元" },
                new Option { QuestionID = 7, Rank = 12, Code = "D12 8 A", Category = "約新台幣 55,001 元至 60,000 元" },
                new Option { QuestionID = 7, Rank = 13, Code = "D13 8 A", Category = "約新台幣 60,001 元至 65,000 元" },
                new Option { QuestionID = 7, Rank = 14, Code = "D14 8 A", Category = "約新台幣 65,001 元至 70,000 元" },
                new Option { QuestionID = 7, Rank = 15, Code = "D15 8 A", Category = "約新台幣 70,001 以上" },
                new Option { QuestionID = 7, Rank = 51, Code = "D16 8 Q", Category = "其他 (請填寫答案)" },

                new Option { QuestionID = 8, Rank = 1,  Code = "Z3 9 A", Category = "境內" },
                new Option { QuestionID = 8, Rank = 2,  Code = "Z4 10 A", Category = "境外" },

                new Option { QuestionID = 9, Rank = 1,  Code = "E1 15 A", Category = "基隆市" },
                new Option { QuestionID = 9, Rank = 2,  Code = "E2 15 A", Category = "新北市" },
                new Option { QuestionID = 9, Rank = 3,  Code = "E3 15 A", Category = "台北市" },
                new Option { QuestionID = 9, Rank = 4,  Code = "E4 15 A", Category = "桃園縣" },
                new Option { QuestionID = 9, Rank = 5,  Code = "E5 15 A", Category = "新竹縣" },
                new Option { QuestionID = 9, Rank = 6,  Code = "E6 15 A", Category = "新竹市" },
                new Option { QuestionID = 9, Rank = 7,  Code = "E7 15 A", Category = "苗栗縣" },
                new Option { QuestionID = 9, Rank = 8,  Code = "E8 15 A", Category = "台中市" },
                new Option { QuestionID = 9, Rank = 9,  Code = "E9 15 A", Category = "南投縣" },
                new Option { QuestionID = 9, Rank = 10, Code = "E10 15 A", Category = "彰化縣" },
                new Option { QuestionID = 9, Rank = 11, Code = "E11 15 A", Category = "雲林縣" },
                new Option { QuestionID = 9, Rank = 12, Code = "E12 15 A", Category = "嘉義縣" },
                new Option { QuestionID = 9, Rank = 13, Code = "E13 15 A", Category = "嘉義市" },
                new Option { QuestionID = 9, Rank = 14, Code = "E14 15 A", Category = "台南市" },
                new Option { QuestionID = 9, Rank = 15, Code = "E15 15 A", Category = "高雄市" },
                new Option { QuestionID = 9, Rank = 16, Code = "E16 15 A", Category = "屏東縣" },
                new Option { QuestionID = 9, Rank = 17, Code = "E17 15 A", Category = "台東縣" },
                new Option { QuestionID = 9, Rank = 18, Code = "E18 15 A", Category = "花蓮縣" },
                new Option { QuestionID = 9, Rank = 19, Code = "E19 15 A", Category = "宜蘭縣" },
                new Option { QuestionID = 9, Rank = 20, Code = "E20 15 A", Category = "連江縣" },
                new Option { QuestionID = 9, Rank = 21, Code = "E21 15 A", Category = "金門縣" },
                new Option { QuestionID = 9, Rank = 22, Code = "E22 15 A", Category = "澎湖縣" },

                new Option { QuestionID = 10, Rank = 51, Code = "E24 15 A", Category = "亞洲(香港,澳門,大陸地區)" },
                new Option { QuestionID = 10, Rank = 52, Code = "E25 15 A", Category = "亞洲(香港,澳門,大陸地區以外國家)" },
                new Option { QuestionID = 10, Rank = 53, Code = "E26 15 A", Category = "大洋洲" },
                new Option { QuestionID = 10, Rank = 54, Code = "E27 15 A", Category = "非洲" },
                new Option { QuestionID = 10, Rank = 55, Code = "E28 15 A", Category = "歐洲" },
                new Option { QuestionID = 10, Rank = 56, Code = "E29 15 A", Category = "北美洲" },
                new Option { QuestionID = 10, Rank = 57, Code = "E30 15 A", Category = "中美洲" },
                new Option { QuestionID = 10, Rank = 58, Code = "E31 15 A", Category = "南美洲" },
                
                new Option { QuestionID = 11, Rank = 1, Code = "F1 23 A", Category = "升學中或進修中" },
                new Option { QuestionID = 11, Rank = 2, Code = "F2 23 A", Category = "服役中或等待服役中" },
                new Option { QuestionID = 11, Rank = 3, Code = "Z5 12 A", Category = "準備考試" },
                new Option { QuestionID = 11, Rank = 4, Code = "Z6 13 A", Category = "尋找工作中" },
                new Option { QuestionID = 11, Rank = 51, Code = "F21 23 A", Category = "其他: 不想找工作,生病 ... (請填寫答案)" },

                new Option { QuestionID = 12, Rank = 1, Code = "F3 23 A", Category = "國內研究所" },
                new Option { QuestionID = 12, Rank = 2, Code = "F4 23 A", Category = "出國留學" },
                new Option { QuestionID = 12, Rank = 3, Code = "F5 23 A", Category = "證照" },
                new Option { QuestionID = 12, Rank = 4, Code = "F6 23 A", Category = "公務人員" },
                new Option { QuestionID = 12, Rank = 51, Code = "F7 23 Q", Category = "其他 (請填寫答案)" },

                new Option { QuestionID = 13, Rank = 1, Code = "F8 14 A", Category = "沒有工作機會" },
                new Option { QuestionID = 13, Rank = 2, Code = "F9 14 A", Category = "薪水不滿意" },
                new Option { QuestionID = 13, Rank = 3, Code = "F10 14 A", Category = "公司財務或制度不穩健" },
                new Option { QuestionID = 13, Rank = 4, Code = "F11 14 A", Category = "工作地點不適合" },
                new Option { QuestionID = 13, Rank = 5, Code = "F12 14 A", Category = "與所學不符" },
                new Option { QuestionID = 13, Rank = 6, Code = "F13 14 A", Category = "不符合家人的期望" },
                new Option { QuestionID = 13, Rank = 7, Code = "F14 14 A", Category = "工作內容不滿意" },
                new Option { QuestionID = 13, Rank = 51, Code = "F22 14 Q", Category = "其他 (請填寫答案)" },

                new Option { QuestionID = 14, Rank = 1, Code = "F15 23 A", Category = "約 1 個月以內" },
                new Option { QuestionID = 14, Rank = 2, Code = "F16 23 A", Category = "約 1 個月以上至 2 個月內" },
                new Option { QuestionID = 14, Rank = 3, Code = "F17 23 A", Category = "約 2 個月以上至 3 個月內" },
                new Option { QuestionID = 14, Rank = 4, Code = "F18 23 A", Category = "約 3 個月以上至 4 個月內" },
                new Option { QuestionID = 14, Rank = 5, Code = "F19 23 A", Category = "約 4 個月以上至 6 個月內" },
                new Option { QuestionID = 14, Rank = 6, Code = "F20 23 A", Category = "約 6 個月以上" },

                new Option { QuestionID = 15, Rank = 1, Code = "G1 16 A", Category = "非常符合" },
                new Option { QuestionID = 15, Rank = 2, Code = "G2 16 A", Category = "符合" },
                new Option { QuestionID = 15, Rank = 3, Code = "G3 16 A", Category = "尚可" },
                new Option { QuestionID = 15, Rank = 4, Code = "G4 16 A", Category = "不符合" },
                new Option { QuestionID = 15, Rank = 5, Code = "G5 16 A", Category = "非常不符合" },

                new Option { QuestionID = 16, Rank = 1, Code = "H1 17 A", Category = "需要" },
                new Option { QuestionID = 16, Rank = 2, Code = "H2 17 A", Category = "不需要" },

                new Option { QuestionID = 17, Rank = 1, Code = "I1 18 A", Category = "非常滿意" },
                new Option { QuestionID = 17, Rank = 2, Code = "I2 18 A", Category = "滿意" },
                new Option { QuestionID = 17, Rank = 3, Code = "I3 18 A", Category = "尚可" },
                new Option { QuestionID = 17, Rank = 4, Code = "I4 18 A", Category = "不滿意" },
                new Option { QuestionID = 17, Rank = 5, Code = "I5 18 A", Category = "非常不滿意" },

                new Option { QuestionID = 18, Rank = 1, Code = "J1 19 A", Category = "非常符合" },
                new Option { QuestionID = 18, Rank = 2, Code = "J2 19 A", Category = "符合" },
                new Option { QuestionID = 18, Rank = 3, Code = "J3 19 A", Category = "尚可" },
                new Option { QuestionID = 18, Rank = 4, Code = "J4 19 A", Category = "不符合" },
                new Option { QuestionID = 18, Rank = 5, Code = "J5 19 A", Category = "非常不符合" },

                new Option { QuestionID = 19, Rank = 1, Code = "K1 20 A", Category = "專業知識,知能傳授" },
                new Option { QuestionID = 19, Rank = 2, Code = "K2 20 A", Category = "同學及老師人脈" },
                new Option { QuestionID = 19, Rank = 3, Code = "K3 20 A", Category = "課程實務/實作活動" },
                new Option { QuestionID = 19, Rank = 4, Code = "K4 20 A", Category = "業界實習" },
                new Option { QuestionID = 19, Rank = 5, Code = "K5 20 A", Category = "社團活動" },
                new Option { QuestionID = 19, Rank = 6, Code = "K6 20 A", Category = "語言學習" },
                new Option { QuestionID = 19, Rank = 7, Code = "K7 20 A", Category = "參與國際交流活動" },
                new Option { QuestionID = 19, Rank = 8, Code = "K8 20 A", Category = "志工服務,服務學習" },
                new Option { QuestionID = 19, Rank = 9, Code = "K9 20 A", Category = "研究或教學助理" },
                new Option { QuestionID = 19, Rank = 51, Code = "K10 20 Q", Category = "其他訓練 (請敘明)" },

                new Option { QuestionID = 20, Rank = 1, Code = "Z7 21 A", Category = "有, 進修" },
                new Option { QuestionID = 20, Rank = 2, Code = "Z8 22 A", Category = "有, 準備考試或其他證照" },
                new Option { QuestionID = 20, Rank = 51, Code = "L3 23 Q", Category = "有, 其他 (請敘明類別)" },
                new Option { QuestionID = 20, Rank = 52, Code = "L10 23 A", Category = "沒有" },

                new Option { QuestionID = 21, Rank = 1, Code = "L1 23 A", Category = "國內大專院校進修" },
                new Option { QuestionID = 21, Rank = 2, Code = "L2 23 A", Category = "出國進修" },

                new Option { QuestionID = 22, Rank = 1, Code = "L3 23 A", Category = "國家考試" },
                new Option { QuestionID = 22, Rank = 2, Code = "L4 23 A", Category = "技術士證照" },
                new Option { QuestionID = 22, Rank = 3, Code = "L5 23 A", Category = "金融證照" },
                new Option { QuestionID = 22, Rank = 4, Code = "L6 23 A", Category = "教師證" },
                new Option { QuestionID = 22, Rank = 5, Code = "L7 23 A", Category = "語言證照" },
                new Option { QuestionID = 22, Rank = 6, Code = "L8 23 A", Category = "電腦認證" },

                new Option { QuestionID = 23, Rank = 1, Code = "Z9 24 A", Category = "有" },
                new Option { QuestionID = 23, Rank = 2, Code = "M11 0 A", Category = "沒有" },

                new Option { QuestionID = 24, Rank = 1, Code = "M1 0 A", Category = "大專院校就業職能平台(UCAN)" },
                new Option { QuestionID = 24, Rank = 2, Code = "M2 0 A", Category = "職涯諮詢,就業諮詢" },
                new Option { QuestionID = 24, Rank = 3, Code = "M3 0 A", Category = "職涯發展課程(演講)及活動" },
                new Option { QuestionID = 24, Rank = 4, Code = "M4 0 A", Category = "業界實習,參訪" },
                new Option { QuestionID = 24, Rank = 5, Code = "M5 0 A", Category = "企業徵才說明會" },
                new Option { QuestionID = 24, Rank = 6, Code = "M6 0 A", Category = "校園企業徵才博覽會" },
                new Option { QuestionID = 24, Rank = 7, Code = "M7 0 A", Category = "定期工作訊息" },
                new Option { QuestionID = 24, Rank = 8, Code = "M8 0 A", Category = "校內工讀" },
                new Option { QuestionID = 24, Rank = 9, Code = "M9 0 A", Category = "校外工讀" },
                new Option { QuestionID = 24, Rank = 51, Code = "M10 0 Q", Category = "其他 (請敘明)" }

            };

            foreach (Option o in options)
            {
                context.Options.Add(o);
            }
            context.SaveChanges();

            var optiontypes = new OptionType[]
            {
                new OptionType { OptionID = 20, Rank = 1, Type = "建築規劃設計" },
                new OptionType { OptionID = 20, Rank = 2, Type = "營造及維護" },

                new OptionType { OptionID = 21, Rank = 1, Type = "生產管理" },
                new OptionType { OptionID = 21, Rank = 2, Type = "製程研發" },
                new OptionType { OptionID = 21, Rank = 3, Type = "設備安裝維護" },
                new OptionType { OptionID = 21, Rank = 4, Type = "品質管理" },
                new OptionType { OptionID = 21, Rank = 5, Type = "資材及庫存規劃" },
                new OptionType { OptionID = 21, Rank = 6, Type = "工業安全管理" },

                new OptionType { OptionID = 22, Rank = 1, Type = "工程及技術" },
                new OptionType { OptionID = 22, Rank = 2, Type = "數學及科學" },

                new OptionType { OptionID = 24, Rank = 1, Type = "運輸作業" },
                new OptionType { OptionID = 24, Rank = 2, Type = "物流規劃及管理" },
                new OptionType { OptionID = 24, Rank = 3, Type = "運輸工程" },
                new OptionType { OptionID = 24, Rank = 4, Type = "運輸規劃及管理" },

                new OptionType { OptionID = 24, Rank = 1, Type = "食品生產與加工" },
                new OptionType { OptionID = 24, Rank = 2, Type = "植物研究發展與應用" },
                new OptionType { OptionID = 24, Rank = 3, Type = "動物研究發展與應用" },
                new OptionType { OptionID = 24, Rank = 4, Type = "自然資源保育" },
                new OptionType { OptionID = 24, Rank = 5, Type = "環境保護與衛生" },
                new OptionType { OptionID = 24, Rank = 6, Type = "農業經營" },

                new OptionType { OptionID = 25, Rank = 1, Type = "醫療服務" },
                new OptionType { OptionID = 25, Rank = 2, Type = "長期照護服務" },
                new OptionType { OptionID = 25, Rank = 3, Type = "公共衛生" },
                new OptionType { OptionID = 25, Rank = 4, Type = "健康產業及醫務管理" },
                new OptionType { OptionID = 25, Rank = 5, Type = "生技研發" },

                new OptionType { OptionID = 26, Rank = 1, Type = "影視傳播" },
                new OptionType { OptionID = 26, Rank = 2, Type = "印刷出版" },
                new OptionType { OptionID = 26, Rank = 3, Type = "視覺藝術" },
                new OptionType { OptionID = 26, Rank = 4, Type = "表演藝術" },
                new OptionType { OptionID = 26, Rank = 5, Type = "新聞傳播" },
                new OptionType { OptionID = 26, Rank = 6, Type = "通訊傳播" },
                new OptionType { OptionID = 26, Rank = 7, Type = "設計產業" },

                new OptionType { OptionID = 27, Rank = 1, Type = "網路規劃與建置管理" },
                new OptionType { OptionID = 27, Rank = 2, Type = "資訊支援與服務" },
                new OptionType { OptionID = 27, Rank = 3, Type = "數位內容與傳播" },
                new OptionType { OptionID = 27, Rank = 4, Type = "軟體開發及程式設計" },

                new OptionType { OptionID = 28, Rank = 1, Type = "證券及投資" },
                new OptionType { OptionID = 28, Rank = 2, Type = "財務" },
                new OptionType { OptionID = 28, Rank = 3, Type = "銀行金融業務" },
                new OptionType { OptionID = 28, Rank = 4, Type = "保險" },
                new OptionType { OptionID = 28, Rank = 5, Type = "會計" },

                new OptionType { OptionID = 29, Rank = 1, Type = "一般管理" },
                new OptionType { OptionID = 29, Rank = 2, Type = "企業資訊管理" },
                new OptionType { OptionID = 29, Rank = 3, Type = "人力資源管理" },
                new OptionType { OptionID = 29, Rank = 4, Type = "運籌管理" },
                new OptionType { OptionID = 29, Rank = 5, Type = "行政支援" },

                new OptionType { OptionID = 30, Rank = 1, Type = "行銷管理" },
                new OptionType { OptionID = 30, Rank = 2, Type = "專業銷售" },
                new OptionType { OptionID = 30, Rank = 3, Type = "行銷傳播" },
                new OptionType { OptionID = 30, Rank = 4, Type = "市場分析研究" },
                new OptionType { OptionID = 30, Rank = 5, Type = "零售與通路管理" },

                new OptionType { OptionID = 31, Rank = 1, Type = "國防" },
                new OptionType { OptionID = 31, Rank = 2, Type = "外交與國際事務" },
                new OptionType { OptionID = 31, Rank = 3, Type = "公共行政" },

                new OptionType { OptionID = 32, Rank = 1, Type = "教育行政" },
                new OptionType { OptionID = 32, Rank = 2, Type = "教學" },

                new OptionType { OptionID = 33, Rank = 1, Type = "學前照護及教育" },
                new OptionType { OptionID = 33, Rank = 2, Type = "心理諮商服務" },
                new OptionType { OptionID = 33, Rank = 3, Type = "社會工作服務" },
                new OptionType { OptionID = 33, Rank = 4, Type = "個人照護服務" },

                new OptionType { OptionID = 34, Rank = 1, Type = "餐飲管理" },
                new OptionType { OptionID = 34, Rank = 2, Type = "旅館管理" },
                new OptionType { OptionID = 34, Rank = 3, Type = "旅遊管理" },
                new OptionType { OptionID = 34, Rank = 4, Type = "休閒遊憩管理" },

                new OptionType { OptionID = 35, Rank = 1, Type = "司法" },
                new OptionType { OptionID = 35, Rank = 2, Type = "公共安全" },
                new OptionType { OptionID = 35, Rank = 3, Type = "法律服務" }
            };

            foreach (OptionType t in optiontypes)
            {
                context.OptionTypes.Add(t);
            }
            context.SaveChanges();
        }
    }
}
