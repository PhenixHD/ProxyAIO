namespace ProxyAIO.UI {
    internal class Designer {

        //Animates Rows or Character based on arguments passed
        public static async Task AnimateText(string text, bool centerText = true, bool drawFullRow = true, ConsoleColor color = ConsoleColor.DarkGray, int delayMilliseconds = 100) {
            string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.ForegroundColor = color;

            if (!drawFullRow) {
                foreach (string line in lines) {
                    if (centerText) {
                        await AnimateCenteredCharacter(line);
                    } else {
                        await AnimateCharacter(line);
                    }
                }
                return;
            }

            foreach (string line in lines) {
                if (centerText) {
                    CenterText(line);
                } else {
                    Console.WriteLine(line);
                }
                await Task.Delay(delayMilliseconds);
            }
            Console.ResetColor();
        }

        //Prints text in center of console
        public static void CenterText(string text) {
            string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.TrimEntries);

            foreach (string line in lines) {
                int spaces = (Console.WindowWidth - line.Length) / 2;
                Console.WriteLine(line.PadLeft(spaces + line.Length));
            }
        }

        //Prints character by character
        private static async Task AnimateCharacter(string text, int delayMilliseconds = 1) {
            foreach (char c in text) {
                Console.Write(c);
                await Task.Delay(delayMilliseconds);
            }
            Console.WriteLine();
        }

        //Prints character by character in center of console
        public static async Task AnimateCenteredCharacter(string text, int delayMilliseconds = 1) {
            string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.TrimEntries);

            foreach (string line in lines) {
                int spaces = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(spaces, Console.CursorTop);

                await AnimateCharacter(line, delayMilliseconds);
            }
        }

        //ASCII banners below
        public static string GetMainMenuArt() {
            return @"╔───────────────────────────────────────╗
│ ___                      _   ___ ___  │
│| _ \_ _ _____ ___  _    /_\ |_ _/ _ \ │
│|  _/ '_/ _ \ \ / || |  / _ \ | | (_) |│
│|_| |_| \___/_\_\\_, | /_/ \_\___\___/ │
│                 |__/                  │
╚───────────────────────────────────────╝";
        }

        public static string GetScraperArt() {
            return @"╔────────────────────────────────────────────────────────╗
│  ___                    ___                            │
│ | _ \_ _ _____ ___  _  / __| __ _ _ __ _ _ __  ___ _ _ │
│ |  _/ '_/ _ \ \ / || | \__ \/ _| '_/ _` | '_ \/ -_) '_|│
│ |_| |_| \___/_\_\\_, | |___/\__|_| \__,_| .__/\___|_|  │
│                  |__/                   |_|            │
╚────────────────────────────────────────────────────────╝";
        }

        public static string GetSettingArt() {
            return @"╔──────────────────────────────────╗
│  ___      _   _   _              │
│ / __| ___| |_| |_(_)_ _  __ _ ___│
│ \__ \/ -_)  _|  _| | ' \/ _` (_-<│
│ |___/\___|\__|\__|_|_||_\__, /__/│
│                         |___/    │
╚──────────────────────────────────╝";
        }

        public static string GetInformationArt() {
            return @"╔─────────────────────────────────────────────────╗
│  ___       __                    _   _          │
│ |_ _|_ _  / _|___ _ _ _ __  __ _| |_(_)___ _ _  │
│  | || ' \|  _/ _ \ '_| '  \/ _` |  _| / _ \ ' \ │
│ |___|_||_|_| \___/_| |_|_|_\__,_|\__|_\___/_||_|│
│                                                 │
╚─────────────────────────────────────────────────╝";
        }

        //Multi-Line Main Menu Art
        public static string GetMainMenuSelection() {
            return @"
[1] Scrape Proxies
[2] Check Proxies
[3] Host Rotating
[4] Settings
[9] Information
[0] Exit";
        }

        public static string GetSettingsMenuSelection() {
            return @"
[1] Timeout
[2] Remove Duplicates";
        }

        public static string GetInformationMenuSelection() {
            return @"
[Application]
Developer Build - Unfinished

[Developer]
Github: https://github.com/PhenixHD";
        }

    }
}