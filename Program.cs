using System;

class Program
{
    static void Main(string[] args)
    {


        Console.CursorVisible = false;
        // tuşa basılırsa oyun ççalışsın
        Console.WriteLine("bir tuşa tıkla ki oyun başlasın.... durdurmak için ESC basılır");
        Console.ReadKey();

        // ekrana yazdırılacak değeri giriyorum.
        char ch = '*';
        bool gameLive = true;
        ConsoleKeyInfo consoleKey; //basılan tuşa göre işlem yaptırmak için kullanıyorun. bunu kullanmasam winapi kullanmam gerekecekti.

        // * karakteri ve console boyut bilgileri
        int x = 0, y = 2; 
        int dx = 0, dy = 0;
        int consoleWidthLimit = 115;
        int consoleHeightLimit = 30;

        // console temizleme
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        // kısaca harakterin hızını ayarlıyorum diyebilirim.
        int delayInMillisecs = 50;

        // izler tutulsun mu?
        bool iz = false;   //deneysel olduğu için bunu bir sonraki muhtemel ödev yılan oyununda kullanabilirim.

        do // esc basılana kadar
        {

            ConsoleColor cc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;

            //hangi tuşa basıldı

            if (Console.KeyAvailable)
            {
          
                 
                Console.SetCursorPosition(x, y);
               
               

                // tuşu çek ve işleme sok
                consoleKey = Console.ReadKey(true);
                switch (consoleKey.Key)
                {
                   
                
                    case ConsoleKey.W: //yukaru
                        dx = 0;
                        dy = -1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case ConsoleKey.S: // aşşa
                        dx = 0;
                        dy = 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case ConsoleKey.A: //sol
                        dx = -1;
                        dy = 0;
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case ConsoleKey.D: //sağ
                        dx = 1;
                        dy = 0;
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case ConsoleKey.Escape: //kapat
                        gameLive = false;
                        break;
                        
                }
            }

            // deneysel iz muhabbetinin devamı 
            Console.SetCursorPosition(x, y);
            if (iz == false)
                Console.Write(' ');

            // yer hesabı
       
            x += dx;
            if (x > consoleWidthLimit)
                x = 0;
            if (x < 0)
                x = consoleWidthLimit;

            y += dy;
            if (y > consoleHeightLimit)
                y = 2; 
            if (y < 2)
                y = consoleHeightLimit;

            // karakter pozisyom
            Console.SetCursorPosition(x, y);
            Console.Write(ch);

            // thread atma 
            System.Threading.Thread.Sleep(delayInMillisecs);

        } while (gameLive);  //oyun devam ettiği sürece 
    }
}