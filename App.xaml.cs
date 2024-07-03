namespace ProTaskMangers02
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Database is != null )
            {
                return;
            }

            MainPage = new AppShell();
        }

        public static SQLite.SQLiteAsyncConnection Database { get; internal set; }
    }
}
