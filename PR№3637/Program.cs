using System.Text;

namespace PR3437 {
    class Program {
        public static void Main () {
            Start:
            Console.Write("Введите длину пароля: ");
            string s_len = Console.ReadLine() ?? "";
            bool can_parse = int.TryParse(s_len, out int len);
            if (can_parse == true) {
                char current_char;
                List<char> password = [];
                Random char_code_generator = new Random();
                for (int i = 1; i <= len; i ++) {
                    int type = char_code_generator.Next(1, 4);
                    switch (type) {
                        case 1:
                            current_char = (char)char_code_generator.Next(48, 58);
                            password.Add(current_char);
                            break;
                        case 2:
                            current_char = (char)char_code_generator.Next(65, 91);
                            password.Add(current_char);
                            break;
                        case 3:
                            current_char = (char)char_code_generator.Next(97, 123);
                            password.Add(current_char);
                            break;
                        default:
                            break;
                    }
                };
                Console.WriteLine(string.Join("", password));
                goto Start;
            }
        }
    }
}
