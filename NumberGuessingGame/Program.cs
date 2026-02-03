using System;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // 랜덤 숫자 생성기 초기화 (Initialize random number generator)
            Random random = new Random();

            // 1부터 100 사이의 임의의 숫자 생성 (Generate a random number between 1 and 100)
            // Next(min, max) 메서드는 min 이상, max 미만의 정수를 반환하므로 1, 101을 사용합니다.
            int targetNumber = random.Next(1, 101);

            int userGuess = 0; // 사용자가 추측한 숫자를 저장할 변수 (Variable to store user's guess)
            int attempts = 0;  // 시도 횟수를 저장할 변수 (Variable to store number of attempts)

            // 게임 시작 메시지 출력 (Print game start message)
            Console.WriteLine("숫자 맞추기 게임에 오신 것을 환영합니다! (Welcome to the Number Guessing Game!)");
            Console.WriteLine("1부터 100 사이의 숫자를 맞춰보세요. (Guess a number between 1 and 100.)");

            // 정답을 맞출 때까지 반복 (Loop until the correct answer is guessed)
            while (userGuess != targetNumber)
            {
                Console.Write("추측한 숫자를 입력하세요 (Enter your guess): ");
                string? input = Console.ReadLine(); // 사용자 입력 받기 (Read user input)

                if (input == null) break; // 입력이 없으면 종료 (Exit if no input)

                // 입력값 유효성 검사 (Input validation)
                // int.TryParse는 문자열을 정수로 변환을 시도합니다. 성공하면 true, 실패하면 false를 반환합니다.
                // 변환된 값은 userGuess 변수에 저장됩니다.
                if (!int.TryParse(input, out userGuess))
                {
                    // 숫자가 아닌 경우 경고 메시지 출력 (Print warning message if input is not a number)
                    Console.WriteLine("유효한 숫자를 입력해주세요. (Please enter a valid number.)");
                    continue; // 반복문의 처음으로 돌아가서 다시 입력받음 (Return to the beginning of the loop)
                }

                attempts++; // 시도 횟수 증가 (Increment attempt count)

                // 추측한 숫자와 정답 비교 (Compare the guess with the target number)
                if (userGuess < targetNumber)
                {
                    // 추측한 숫자가 정답보다 작은 경우 (If guess is lower than target)
                    Console.WriteLine("Up!");
                }
                else if (userGuess > targetNumber)
                {
                    // 추측한 숫자가 정답보다 큰 경우 (If guess is higher than target)
                    Console.WriteLine("Down!");
                }
                else
                {
                    // 정답을 맞춘 경우 (If guess is correct)
                    Console.WriteLine($"Correct! 정답입니다! (Correct!)");
                    Console.WriteLine($"총 시도 횟수: {attempts}번 (Total attempts: {attempts})");
                }
            }

            // 프로그램 종료 전 키 입력 대기 (Wait for key press before exiting)
            Console.WriteLine("게임을 종료하려면 아무 키나 누르세요... (Press any key to exit...)");
            Console.ReadKey();
        }
    }
}
