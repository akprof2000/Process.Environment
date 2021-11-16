# Основные функции для работы со средой

В данном компоненте реализованные следующие функции

![Диаграма классов](ClassDiagram.png)


### Статический класс для получения идентификаторов процесса
```cs
namespace Process.Environment
{
    /// <summary>
    /// Current Environment for using in project
    /// </summary>
    public static class CurrentEnvironment
    {
	    /// Gets or sets the container.
        /// The container.
        public static string Container // Возвращает текущее имя контейнера
        /// Gets the unique identifier.
        /// The unique identifier.
        public static string UniqueID // Возвращает уникальный идентификатор GUID маленькими буквами без дефисов и скобок действительный на все время работы приложения

        /// Gets the unique identifier now.
        /// The unique identifier now.
        public static string UniqueIDNow // Возвращает уникальный идентификатор GUID маленькими буквами без дефисов и скобок при каждом запросе новый идентификатор


    }
}
```

### Атрибут для пропуска тестирования

```cs
namespace Process.Environment
{
    /// Attribute for skip coverage test
    public class NotNeedTestingAttribute : Attribute //при установке данного атрибута проверка на покрытие кода тестами будет исключена для объекта кода с данным атрибутом
}
```
### Статический класс упрощающий работы с DateTime
```cs
	/// Adds the workdays.
    public static DateTime AddWorkdays(this DateTime originalDate, int workDays) // Добавляем только рабочие дни

    /// Determines whether this instance is holiday.
    public static bool IsHoliday(this DateTime originalDate) // проверка на праздники пока только новый год май и восьмое марта
```

### Статический класс упрощающий работы с JSON

```cs
namespace Process.Environment
{
    /// extension methods for JSON
    public static class JHelp
    {

        /// From json.
        public static object FromJson(this string value, Type tp)

        /// From json.
        public static T FromJson<T>(this string value)

        /// Froms the json automatic.
        public static object FromJsonAuto(this string value, Type tp)

        /// Froms the json automatic.
        public static T FromJsonAuto<T>(this string value)

        /// Froms the json all.
        public static object FromJsonAll(this string value, Type tp)

        /// Froms the json all.
        public static T FromJsonAll<T>(this string value)

        /// Converts to json.
        public static string ToJson(this object value)

        /// Converts to json.
        public static string ToJson(this object value, bool formating)

        /// Converts to json auto.
        public static string ToJsonAuto(this object value)

        /// Converts to json auto.
        public static string ToJsonAuto(this object value, bool formating)

        /// Converts to json all.
        public static string ToJsonAll(this object value)

        /// Converts to json all.
        public static string ToJsonAll(this object value, bool formating)

        /// Memories the stream to json.
        public static string MemoryStreamToJson(this MemoryStream value)

        /// Memories the stream from json.
        public static object MemoryStreamFromJson(this string value)

        /// Converts to.
        public static T ConvertTo<T>(this string data)

    }

}

```