using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ChatBotXML
{
    class ChatBotXML
    {
        static string fileJokes = "System/jokes.xml";
        static string fileAphorisms = "System/aphorisms.xlm";
        public ChatBotXML()
        {
            InitXmlFiles();
        }
        ~ChatBotXML()
        {
            foreach (string directoryName in Directory.EnumerateDirectories("System"))
                Directory.Delete(directoryName);
            foreach (string fileName in Directory.EnumerateFiles("system"))
                File.Delete(fileName);
            Directory.Delete("System");
        }
        private static string GetAphorism(int index)
        {
            try
            {
                FileStream file = new FileStream(fileAphorisms, FileMode.Open);
                XmlTextReader fileXML = new XmlTextReader(file);
                fileXML.WhitespaceHandling = WhitespaceHandling.None;
                fileXML.MoveToContent();
                string result = null;
                for (int i = 0; !fileXML.EOF && i < index; i++)
                {
                    result = fileXML.GetAttribute("aphorism");
                    fileXML.Read();
                }
                return result;
            }
            catch
            {
                return null;

            }
        }
        private static string GetJoke(int index)
        {
            string result = null;
            try
            {
                FileStream file = new FileStream(fileJokes, FileMode.Open);
                XmlTextReader fileXML = new XmlTextReader(file);
                fileXML.WhitespaceHandling = WhitespaceHandling.None;
                fileXML.MoveToContent();
                for (int i = 0; !fileXML.EOF && i < index; i++)
                {
                    result = fileXML.GetAttribute("joke");
                    fileXML.Read();
                }
            }
            catch
            { }
            return result;
        }
        private void InitXmlFiles()
        {
            Directory.CreateDirectory("System");
            string[] parametrs = new string[] {
                "Едет мужик в поезде. Достает банан, посыпает его солью и выкидывает в окно. Посыпает солью и выкидывает в окно. Продолжалось так минут 10. И его сосед не выдерживает и спрашивает:\r\n" +
                "  - Мужик, ты зачем это делаешь?\r\n" +
                "  - Да я просто бананы соленые не люблю",
                "Заходит как-то афроамериканц с попугаем в бар,подходит к бармену,бармен спрашивает:\r\n" +
                "  -Где купил?\r\n" +
                "Попугай отвечает:\r\n" +
                "  -В Африке",
                "Как отличить зайца от зайчихи? Очень просто. Взять за уши и кинуть на землю, если побежал - это заяц, а если побежала - зайчиха",
                "Наркоманы такие трудяги, с утра до вечера вкалывают",
                "Когда черепашка вырастает, она становится черепавлом",
                "Что делает глухой гинеколог? Читает по губам",
                "Почему африканские купюры легко подделать? На них не водяных знаков",
                "Кого больше всего боится конная полиция? Цыган",
                "Что банан сказал вибратору? Чего трясёшься, съест то она меня",
                "Идёт мужик по лесу,видит подкова лежит, перевернул,а там конь",
                "Ученые выяснили что от классической музыки цветы растут быстрее а когда они включили около цветов панк рок то земля высохла цветы завяли а горшок умер",
                "Что ищет шепелявый пират? Фундук",
                "Гена с Чебурашкой купили косячок. Приходят домой.\r\n" +
                "Гена говорит:\r\n" +
                "  -Чебурашка, я пойду приму ванну, помоюсь немного и потом раскурим с тобой косяк. Только ты падла не кури без меня.\r\n" +
                "Чебурашка:\r\n" +
                "  -Нет Гена, ты что. Я без тебя не буду.\r\n" +
                "Ну уходит Гена в ванну. Чебурашка сел телик смотреть. Сидит делать нечего, по я щику одну хрень показывают.\r\n" +
                "Ну думает:\r\n" +
                "  -Дай я хапану немного, мол незаметит. Ну и начал курить. М.. М.. м.. И все скурил. Сидит и думает… Е-мое, меня же Гена убъет. Надо беломора затолкать.\r\n" +
                "И тут голос из ванной:\t\n" +
                "  -Чебурашка, приниси полотенце!\r\n" +
                "Бля… Полотенце. Щас спалюсь. Че делать? ТАк… так-так-так, что надо делать. Ага. Надо пойти в комнату, открыть шкаф, взять полотенце, закрыть шкаф.\r\n" +
                "А тут опять голос из ванной:\r\n" +
                "  -Чебурашка!!! Мать твою, где полотенце?\r\n" +
                "Тот весь на изводе. Че делать. Собирается с мыслями. Ну приходит в комнату…. Стоит, думает. Нахуя я сюда пришел? Опять голос из ванной.\r\n" +
                "  -Где полотенце?!А-а-а-… полотенце!!!\r\n" +
                "Подходит к шкафу, открывает дверь берет полотенце и уходит. Там Гена уже заебался ждать. Чебурашка думает, как сказать ему? Ведь щас запалит. И пиздец мне будет.\r\n" +
                "  -Так… Гена… Помнишь ты просил меня принести полотенце? Вот твое… Нет. Спалит бля. Че же делать… Геннадий, вот твое… Тьфу ты бля. почему Геннадий?\r\n" +
                "Гена:\r\n" +
                "  -Чебурашка! Ну че ты там?!\r\n" +
                "  -Все… думает Чебурашка, надо идти. Как сказать. А.. Гена на, Гена на, Гена на, Гена на ААААААА, Крокодил в ванной!!!!!!!!!!",
                "Корова лезет на дерево. Пастух её спрашивает:\r\n" +
                "  -Нахуй ты лезешь на дерево?\r\n" +
                "  -Яблоки кушать\r\n" +
                "  -Ты ебанулась? Это же берёза!\r\n" +
                "  -А у меня с собой!",
                "О чем думает зоофил с некрофильскими наклонностями? Где собака зарыта",
                "Многие считают, что тиранозавры могут хлопать из-за своих коротких лапок, но на самом деле они не могут хлопать, потому что они вымерли",
                "Инопланетяне, похищенные другими инопланетянами, чувствуют себя не в своей тарелке",
            };
            FileStream file = File.Create(fileJokes);
            XmlTextWriter fileXML = new XmlTextWriter(file, Encoding.Unicode);
            fileXML.Formatting = Formatting.Indented;
            fileXML.WriteStartDocument();
            foreach (string element in parametrs)
            {
                fileXML.WriteStartElement("Joke");
                fileXML.WriteAttributeString("joke", element);
            }
            fileXML.WriteEndElement();
            fileXML.WriteEndDocument();
            fileXML.Close();
            file.Close();

            parametrs = new string[]
            {
                "Драгоценный камень нельзя отполировать без трения. Также и человек не может стать успешным без достаточного количества трудных попыток.",
                "Если тебе плюют в спину — значит ты идешь впереди.",
                "Если в человеке естество затмит воспитанность, получится дикарь, а если воспитанность затмит естество, получится знаток писаний. Лишь тот, в ком естество и воспитанность пребывают в равновесии, может считаться достойным мужем.",
                "Как мы можем знать, что такое смерть, когда мы не знаем еще, что такое жизнь?",
                "Мудрый человек не делает другим того, чего он не желает, чтобы ему сделали",
                "Не беспокойся о том, что тебя не знают. Беспокойся о том, достоин ли ты того, чтобы тебя знали.",
                "Не поговорить с человеком, который достоин разговора, значит потерять человека. А говорить с человеком, который разговора не достоин, — значит терять слова. Мудрый не теряет ни людей, ни слов",
                "Порой мы видим многое, но не замечаем главного.",
                "Три пути ведут к знанию: путь размышления — это путь самый благородный, путь подражания — это путь самый лёгкий и путь опыта — это путь самый горький",
                "Я не понимаю, как можно иметь дело с человеком, которому нельзя доверять? Если в повозке нет оси, как можно на ней ездить?",
                "Учитесь так, словно вы постоянно ощущаете нехватку своих знаний, и так, словно вы постоянно боитесь растерять свои знания.",
                "Когда, совершив ошибку, не исправил ее, это и называется совершить ошибку.",
                "Учение без размышления бесполезно, но и размышление без учения опасно.",
                "Не тот велик, кто никогда не падал, а тот велик — кто падал и вставал.",
                "Красота есть во всем, но не всем дано это видеть.",
                "Благородный человек предъявляет требования к себе, низкий человек предъявляет требования к другим.",
                "На самом деле, жизнь проста, но мы настойчиво её усложняем.",
                "Счастье — это когда тебя понимают, большое счастье — это когда тебя любят, настоящее счастье — это когда любишь ты.",
                "Давай наставления только тому, кто ищет знаний, обнаружив свое невежество.",
                "Если ты ненавидишь — значит тебя победили."
            };
            file = File.Create(fileAphorisms);
            fileXML = new XmlTextWriter(file, Encoding.Unicode);
            fileXML.Formatting = Formatting.Indented;
            fileXML.WriteStartDocument();
            foreach (string element in parametrs)
            {
                fileXML.WriteStartElement("Aphorism");
                fileXML.WriteAttributeString("aphorism", element);
            }
            fileXML.WriteEndElement();
            fileXML.WriteEndDocument();
            fileXML.Close();
            file.Close();
        }
        private bool isHellows(string s) => s == "Доброе утро" || s == "Добрый день" || s == "Добрый вечер" || s == "Доброй ночи" || s == "Привет" || s == "Здравствуй" || s == "Здравствуйте";
        public string Ask(string question)
        {
            if (isHellows(question))
                return DateTime.Now.Hour >= 4 && DateTime.Now.Hour < 11 ? "Доброе утро" : DateTime.Now.Hour >= 11 && DateTime.Now.Hour <= 18 ? "Добрый день" :
                         DateTime.Now.Hour > 18 && DateTime.Now.Hour < 21 ? "Добрый вечер" : "Доброй ночи";
            switch(question)
            {
                case "Как тебя зовут?":
                    return "Шарпик";
                case "Сколько времени?":
                    return $"{DateTime.Now.Hour} : {DateTime.Now.Minute}";
                case "Который час?":
                    return $"{DateTime.Now.Hour} : {DateTime.Now.Minute}";
                case "Анекдот":
                    return GetJoke(new Random().Next(1, 17));
                case "Пока":
                    return "Пока";
                case "До свидания":
                    return "До свидания";
                default:
                    return GetAphorism(new Random().Next(1, 20));
            }
        }
    }
}
