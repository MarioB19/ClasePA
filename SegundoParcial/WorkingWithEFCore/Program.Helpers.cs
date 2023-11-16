
partial class Program{
    static void Sectiontitle(string title){
ConsoleColor BackGroundColor=ForegroundColor;
ForegroundColor=ConsoleColor.Cyan;
Write("*");
Write($"{title}");
WriteLine("*");
ForegroundColor=BackGroundColor;
    }
    static void Fail(string message){
    ConsoleColor BackGroundColor=ForegroundColor;
    ForegroundColor=ConsoleColor.Red;
    Write("*");
    Write($"{message}");
WriteLine("*");
    ForegroundColor=BackGroundColor;
}

 static void Info(string message){
    ConsoleColor BackGroundColor=ForegroundColor;
    ForegroundColor=ConsoleColor.Blue;
    Write("*");
    Write($"{message}");
WriteLine("*");
    ForegroundColor=BackGroundColor;
}
}