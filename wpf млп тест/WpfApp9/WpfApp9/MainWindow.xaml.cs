using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace mlpQuiz
{
    public partial class MainWindow : Window
    {
        private List<Question> questions;
        private int index = 0;
        private int score = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadQuestions();
            ShowQuestion();
        }

        private void LoadQuestions()
        {
            questions = new List<Question>
            {
                new Question("Кто элемент честности в май литл пони?", new[]{ "Ренбоу Дэш", "Пинки Пай", "Эплджек" }, 2),
                new Question("Кто являлся злодеем в 'девочки в эквестрии'?", new[]{ "Сансет Шиммер", "Твайлайт Спаркл", "Дёрпи" }, 0),
                new Question("Кто обладает магией в вселенной млп?", new[]{ "Пегасы", "Единороги", "Все" }, 2),
                new Question("К какой расе принадлежит Зекора?", new[]{ "Зебра", "Пони", "Грифон" }, 0),
                new Question("Кто напал на кристальную империю во второй раз?", new[]{ "Найтмермун", "Король Сомбра", "Кризалис" }, 1),
                new Question("В каком сезоне Твайлат стала аликорном?", new[]{ "В пятом", "В третьем", "В седьмом" }, 1),
                new Question("Персонажи из главной шестёрки которые имеют брата:", new[]{ "Эплджек, Флатершай, Твайлайт", "Ренбоу Дэш, Пинки Пай, Рарити", "Никто" }, 0),
                new Question("Как зовут дочь Каденс?", new[]{ "Коузи", "Вельвет", "Флури" }, 2),
                new Question("У кого питомец с именем Опалесенс?", new[]{ "Рарити", "Трикси", "Бабуля Смит" }, 0),
                new Question("Где проживает Брейбёрн?", new[]{ "Клаудсдейл", "Понивиль", "Эппллуза" }, 2),
                new Question("С кем в детсве дружила Эплджнек?", new[]{ "Неизвестно", "Колоратура", "Серенада" }, 1),
                new Question("Кто принимал экзамены в чудомолниях?", new[]{ "Мисти Флай", "Соарин", "Спитфайер" }, 0),
                new Question("Кто создал утопический город?", new[]{ "Старлайт", "Дискорд", "Коузи Глоу" }, 0),
                new Question("В каких играх участвовал Спайк среди других дарконов?", new[]{ "Игры драконов", "Проклятье Пещер", "Испытания огнём" }, 2),
                new Question("Кто самый могущественный маг из злодеев?", new[]{ "Дискорд", "Грогар", "Тирек" }, 0),
                new Question("У кого хорошо развита интуиция?", new[]{ "Крошка Бель", "Пинки Пай", "Табита" }, 1),
                new Question("Чем питаются перевёртыши?", new[]{ "Любовью", "Дружбой", "Негативными эмоциями" }, 0),
                new Question("Кто был учеником Селестии до Твайлайт?", new[]{ "Старлайт Глиммер", "Флеш Сентри", "Сансет Шиммер" }, 2),
                new Question("Какого города не существут?", new[]{ "Хаосвиль", "Мейнхеттен", "Джанколейл" }, 1),
                new Question("Что является древней реликвией кристальной империи?", new[]{ "Амулет Аликорна", "Кристальное сердце", "Жезл равенства" }, 1)
            };
        }

        private void ShowQuestion()
        {
            if (index >= questions.Count)
            {
              QuestionText.Text = "тест окончен";
              AnswersPanel.Children.Clear();
              ResultText.Text = $"результат: {score} / {questions.Count}";
              return;
            }

            var q = questions[index];
            QuestionText.Text = q.Text;
            AnswersPanel.Children.Clear();

            for (int i = 0; i < q.Answers.Length; i++)
            {
               var rb = new RadioButton { Content = q.Answers[i], Tag = i, Margin = new Thickness(0, 5, 0, 5) };
               AnswersPanel.Children.Add(rb);
            }
        }

        private void AnswerClick(object sender, RoutedEventArgs e)
        {
            foreach (var child in AnswersPanel.Children)
            {
                if (child is RadioButton rb && rb.IsChecked == true)
                {
                    if ((int)rb.Tag == questions[index].CorrectIndex)
                        score++;
                    break;
                }
            }

            index++;
            ShowQuestion();
        }
    }

    public class Question
    {
        public string Text { get; }
        public string[] Answers { get; }
        public int CorrectIndex { get; }

        public Question(string text, string[] answers, int correctIndex)
        {
            Text = text;
            Answers = answers;
            CorrectIndex = correctIndex;
        }
    }
}
