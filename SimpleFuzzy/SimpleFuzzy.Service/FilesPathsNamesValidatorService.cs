using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public class FilesPathsNamesValidatorService : IFilesPathsNamesValidator
    {
        // Зарезервированные имена файлов
        private readonly string[] ReservedNames = new[] {
        "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9",
        "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
        "PRN", "AUX", "NUL", "CON", "CLOCK$"
    };

        // Недопустимые символы
        private readonly char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();
        private readonly char[] InvalidPathChars = Path.GetInvalidPathChars();

        // Максимальная длина имени файла
        private const int MaxComponentLength = 255;
        // Максимальная длина пути
        private const int MaxPathLength = 2048;

        // Максимальная глубина подкаталогов
        private const int MaxDepth = 250;
        // Метод для проверки имени файла
        public bool IsValidFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return false;

            // Проверка длины компонента файла
            if (fileName.Length > MaxComponentLength) return false;

            // Проверка на зарезервированные имена
            if (ReservedNames.Contains(fileName.ToUpper())) return false;

            // Проверка на недопустимые символы
            if (fileName.IndexOfAny(InvalidFileNameChars) >= 0) return false;

            // Проверка на недопустимые символы Юникода
            if (!IsValidUnicode(fileName)) return false;

            return true;
        }

        // Метод для проверки имени каталога
        public bool IsValidDirectoryName(string directoryName)
        {
            if (string.IsNullOrEmpty(directoryName)) return false;
            // Проверка длины всего пути
            if (directoryName.Length > MaxPathLength) return false;
            // Разделение пути на компоненты
            string[] pathComponents = directoryName.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            // Проверка глубины подкаталогов
            if (pathComponents.Length > MaxDepth) return false;
            foreach (string component in pathComponents)
            {
                // Проверка длины каждого компонента каталога
                if (component.Length > MaxComponentLength) return false;

                // Проверка на зарезервированные имена
                if (ReservedNames.Contains(component.ToUpper())) return false;

                // Проверка на недопустимые символы
                if (component.IndexOfAny(InvalidPathChars) >= 0) return false;

                // Проверка на недопустимые символы Юникода
                if (!IsValidUnicode(component)) return false;
            }

            return true;
        }

        // Метод для проверки допустимости Юникода
        private bool IsValidUnicode(string input)
        {
            foreach (char c in input)
            {
                if (char.IsSurrogate(c) || char.IsControl(c) || c == '\uE000' || c == '\uFFFE' || c == '\uFFFF')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
