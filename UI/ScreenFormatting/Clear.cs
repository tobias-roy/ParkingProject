namespace UI.Screen
{
  public class Text
    {
        ///<summary>
        ///Clears the top 8 rows and sets cursor on position 0,0
        ///</summary>
        public static void ClearTop()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(0,i);
                Console.WriteLine(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0,0);
            }
        }

        public static void ClearExceptionMessage(){
            Console.SetCursorPosition(0, 10);
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
    }
}
