namespace Harmic.Areas.Admin.Models
{
    public class SummerNote
    {
        public SummerNote(string idEditor, bool loadLibrary = true)
        {
            IdEditor = idEditor;
            LoadLibrary = loadLibrary;
        }
        public string IdEditor { get; set; }
        public bool LoadLibrary { get; set; }
        public int Height { get; set; } = 500;
        public string toolBar { get; set; } = @"
        [
            ['style', ['style']],
            ['font',['underline','bold', 'clear']],
            ['color',['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['table', ['table']],
            ['insert', ['link', 'elfinderFiles','video', 'elfinder']],
            ['view', ['fullscreen', 'codeview', 'help']]
        ]
            ";
    }
}
