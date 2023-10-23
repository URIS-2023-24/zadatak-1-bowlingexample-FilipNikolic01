Random random = new Random();
int[] score = new int[10];
int overallScore = 0;
int firstThrow = 0;
int secondThrow = 0;
bool isPreviousStrike = false;
bool isPreviousSpare = false;

for (int i = 0; i < 10; i++)
{
    firstThrow = random.Next(0, 11);
    if (isPreviousStrike || isPreviousSpare)
    {
        score[i - 1] += firstThrow;
    }

    if (firstThrow == 10)
    {
        score[i] = firstThrow;
        isPreviousStrike = true;
        isPreviousSpare = false;
        if (i == 9 && isPreviousStrike)
        {
            firstThrow = random.Next(0, 11);
            score[i] += firstThrow;
            secondThrow = random.Next(0, 11 - firstThrow);
            score[i] += secondThrow;
        }
        continue;
    }

    secondThrow = random.Next(0, 11 - firstThrow);
    if (isPreviousStrike)
    {
        score[i - 1] += secondThrow;
    }
    if (firstThrow + secondThrow == 10)
    {
        score[i] += firstThrow + secondThrow;
        isPreviousStrike = false;
        isPreviousSpare = true;
        if (i == 9 && isPreviousSpare)
        {
            firstThrow = random.Next(0, 11);
            score[i] += firstThrow;
        }
        continue;
    }

    score[i] = firstThrow + secondThrow;
    isPreviousSpare = false;
    isPreviousStrike = false;
}

for (int i = 0; i < score.Length; i++)
{
    Console.WriteLine($"Frame {i + 1}: { score[i]}");
    overallScore += score[i];
}

Console.WriteLine($"Overall Score: {overallScore}");
