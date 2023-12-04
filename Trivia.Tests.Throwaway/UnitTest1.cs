using Trivia.Core;

namespace Trivia.Tests.Throwaway
{
    [TestClass]
    public class UnitTest1 : VerifyBase
    {
        [TestMethod]
        public Task TestMethod1()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            Game aGame = new Game();

            int[] rand = { 1, 2, 3, 4, 2, 5, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6 };
            int rounds = 0;
            int[] wrongRounds = { 2, 3, 6 };

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            bool _notAWinner = true;
            do
            {
                aGame.roll(rand[rounds]);

                if (wrongRounds.Contains(rounds))
                {
                    aGame.wrongAnswer();
                }
                else
                {
                    _notAWinner = aGame.wasCorrectlyAnswered();
                }

                rounds++;
            } while (_notAWinner);

            return Verify(sw.ToString());
        }
    }
}