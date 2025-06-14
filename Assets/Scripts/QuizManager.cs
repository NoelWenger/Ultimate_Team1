using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public TextMeshProUGUI scoreText;

    public List<Question> questions = new List<Question>();
    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        // Punkte aus PlayerPrefs laden
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Punkte: " + score;
        LoadQuestions();
        DisplayQuestion();
    }

    void LoadQuestions()
    {
        questions = new List<Question>()
    {
        new Question { questionText = "Wie viele Spieler hat eine Fussballmannschaft?", answers = new string[] { "10", "11", "9", "12" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wie viele Minuten dauert ein Fussballspiel normalerweise?", answers = new string[] { "90", "80", "100", "70" }, correctAnswerIndex = 0 },
        new Question { questionText = "Welches Land hat die meisten WM-Titel?", answers = new string[] { "Deutschland", "Brasilien", "Italien", "Argentinien" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wie viele Punkte bekommt man fuer einen Sieg?", answers = new string[] { "1", "2", "3", "4" }, correctAnswerIndex = 2 },
        new Question { questionText = "Welche Position spielt Manuel Neuer?", answers = new string[] { "Stuermer", "Verteidiger", "Torwart", "Mittelfeld" }, correctAnswerIndex = 2 },
        new Question { questionText = "Was ist die maximale Anzahl an Auswechslungen in einem normalen Spiel?", answers = new string[] { "3", "5", "4", "6" }, correctAnswerIndex = 1 },
        new Question { questionText = "Welcher Spieler hat die meisten Tore bei einer WM geschossen?", answers = new string[] { "Miroslav Klose", "Ronaldo", "Pele", "Messi" }, correctAnswerIndex = 0 },
        new Question { questionText = "Wie nennt man es, wenn ein Spieler drei Tore schiesst?", answers = new string[] { "Triple", "Hattrick", "Dreier", "Trio" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wie gross ist ein Fussballfeld ungefaehr?", answers = new string[] { "90m x 45m", "100m x 50m", "105m x 68m", "110m x 60m" }, correctAnswerIndex = 2 },
        new Question { questionText = "Welcher Verein hat die meisten Champions-League-Titel?", answers = new string[] { "Barcelona", "Bayern", "Liverpool", "Real Madrid" }, correctAnswerIndex = 3 },

        new Question { questionText = "Wie viele Halbzeiten hat ein Fussballspiel?", answers = new string[] { "1", "2", "3", "4" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wie lange dauert eine Halbzeit in einem Fussballspiel?", answers = new string[] { "30 Minuten", "45 Minuten", "60 Minuten", "50 Minuten" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wie viele Spieler sind maximal auf der Ersatzbank?", answers = new string[] { "7", "9", "12", "11" }, correctAnswerIndex = 0 },
        new Question { questionText = "Wie heisst die schweizer Fussballliga?", answers = new string[] { "Super League", "Bundesliga", "Premier League", "Serie A" }, correctAnswerIndex = 0 },
        new Question { questionText = "Was bedeutet Abseits im Fussball?", answers = new string[] { "Wenn ein Spieler zu frueh angreift", "Wenn ein Spieler hinter der gegnerischen Abwehr ist", "Wenn ein Spieler regelwidrig den Ball beruehrt", "Wenn ein Spieler sich ausserhalb des Spielfelds befindet" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wie viele Schiedsrichter sind in einem offiziellen Spiel?", answers = new string[] { "1", "2", "3", "4" }, correctAnswerIndex = 2 },
        new Question { questionText = "Welche Farbe hat die Karte fuer eine grobe Regelverletzung?", answers = new string[] { "Gelb", "Rot", "Gruen", "Blau" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wer gewann die Fussball-Europameisterschaft 2020?", answers = new string[] { "Frankreich", "Italien", "England", "Spanien" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wie heisst die offizielle Fussball-Weltmeisterschaft?", answers = new string[] { "FIFA World Cup", "UEFA Champions League", "Copa America", "Confederations Cup" }, correctAnswerIndex = 0 },
        new Question { questionText = "Welcher Spieler hat die meisten Ballon d'Or gewonnen?", answers = new string[] { "Cristiano Ronaldo", "Lionel Messi", "Michel Platini", "Johan Cruyff" }, correctAnswerIndex = 1 },

        new Question { questionText = "Welches Land war Gastgeber der WM 2018?", answers = new string[] { "Russland", "Brasilien", "Deutschland", "Suedafrika" }, correctAnswerIndex = 0 },
        new Question { questionText = "Was passiert bei einem Foulspiel?", answers = new string[] { "Freistoss", "Ecke", "Abstoss", "Anstoss" }, correctAnswerIndex = 0 },
        new Question { questionText = "Welcher Schweizer Spieler ist bekannt als 'Djibril Sow'?", answers = new string[] { "Mittelfeldspieler", "Verteidiger", "Torwart", "Stuermer" }, correctAnswerIndex = 0 },
        new Question { questionText = "Wie oft fand die erste Fussball-Weltmeisterschaft statt?", answers = new string[] { "1904", "1920", "1930", "1950" }, correctAnswerIndex = 2 },
        new Question { questionText = "Wie viele Tore sind in einem Handspiel erlaubt?", answers = new string[] { "0", "1", "2", "3" }, correctAnswerIndex = 0 },
        new Question { questionText = "Welcher Spieler ist bekannt fuer seine besondere Technik und wird 'Die Fledermaus' genannt?", answers = new string[] { "David Alaba", "Gianluigi Buffon", "Luis Figo", "Sergio Ramos" }, correctAnswerIndex = 3 },
        new Question { questionText = "Welches Land gewann die Fussball-EM 2016?", answers = new string[] { "Portugal", "Frankreich", "Deutschland", "Italien" }, correctAnswerIndex = 0 },
        new Question { questionText = "Was ist die Aufgabe eines Verteidigers?", answers = new string[] { "Tore schiessen", "Gegnerische Angriffe stoppen", "Elfmeter schiessen", "Tore verhindern" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wie nennt man die Ausfuehrung eines Eckballs?", answers = new string[] { "Corner", "Freistoss", "Anstoss", "Abstoss" }, correctAnswerIndex = 0 },
        new Question { questionText = "Welche Farbe hat die Karte fuer eine Verwarnung?", answers = new string[] { "Gelb", "Rot", "Blau", "Gruen" }, correctAnswerIndex = 0 },
        new Question { questionText = "Wie heisst die offizielle Organisation des Fussballs?", answers = new string[] { "FIFA", "UEFA", "CONMEBOL", "AFC" }, correctAnswerIndex = 0 },
        new Question { questionText = "Was ist ein Elfmeter?", answers = new string[] { "Foul im Strafraum", "Freistoss", "Strafstoss", "Ecke" }, correctAnswerIndex = 2 },
        new Question { questionText = "Wie viele Spieler stehen in der Startelf eines Fussballspiels?", answers = new string[] { "10", "11", "12", "9" }, correctAnswerIndex = 1 },
        new Question { questionText = "Wie viele Tore hat Lionel Messi fuer Argentinien geschossen (Stand 2021)?", answers = new string[] { "70", "80", "90", "75" }, correctAnswerIndex = 3 },
        new Question { questionText = "Welcher Spieler gilt als 'König des Fussballs'?", answers = new string[] { "Pele", "Diego Maradona", "Lionel Messi", "Cristiano Ronaldo" }, correctAnswerIndex = 0 },
        new Question { questionText = "Was bedeutet 'Dribbeln' im Fussball?", answers = new string[] { "Den Ball kontrollieren und am Gegner vorbeibewegen", "Den Ball abspielen", "Den Ball stoppen", "Den Ball schiessen" }, correctAnswerIndex = 0 },
        new Question { questionText = "Wie heisst der deutsche Fussball-Bund?", answers = new string[] { "DFB", "DFL", "DFU", "FIFA" }, correctAnswerIndex = 0 },
    };
    }


    void DisplayQuestion()
    {
        if (currentQuestionIndex >= questions.Count)
        {
            Debug.Log("Quiz beendet! Dein Punktestand: " + score);
            return;
        }

        Question q = questions[currentQuestionIndex];
        questionText.text = q.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerClicked(index));
        }
    }

    void OnAnswerClicked(int index)
    {
        // Überprüfen, ob die Antwort richtig war
        if (index == questions[currentQuestionIndex].correctAnswerIndex)
        {
            Debug.Log("Richtige Antwort!");
            score += 10; // z. B. 10 Punkte pro richtiger Antwort
        }
        else
        {
            Debug.Log("Falsche Antwort.");
        }

        // Zum nächsten Index wechseln, aber nur, wenn noch Fragen vorhanden sind
        currentQuestionIndex++;

        // Wenn noch Fragen übrig sind, zeige die nächste Frage an
        if (currentQuestionIndex < questions.Count)
        {
            DisplayQuestion(); // Methode, um die Frage zu aktualisieren
        }
        else
        {
            // Quiz beendet, zeige die Punktzahl an
            ShowFinalScore(); // Funktion, die die Punktzahl anzeigt
        }

        // Aktualisiere den Punktestand
        scoreText.text = "Punkte: " + score;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save(); // Speichere den Punktestand
    }

    void ShowFinalScore()
    {
        // Zeige die Punktzahl auf dem UI-Text an
        scoreText.text = "Deine Gesamtpunktzahl: " + score;
        PlayerPrefs.SetInt("Score", score);  // Speichere den Punktestand am Ende
        PlayerPrefs.Save();
    }

    public void BackToMainMenu()
    {
        // Zurück ins MainMenu
        PlayerPrefs.SetInt("Score", score); // Speichere den Punktestand vor dem Verlassen
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
