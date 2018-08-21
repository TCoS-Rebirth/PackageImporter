#if NET_4_6
using System.IO;
using System.Text;
using Engine;
using Mono.CSharp;
using SBBase;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    class ScriptPad:EditorWindow
    {

        [MenuItem("Spellborn/ScriptPad")]
        static void Open()
        {
            GetWindow<ScriptPad>("ScriptPad");
        }

        [SerializeField] string txt;

        void OnEnable()
        {
            var settings = new CompilerSettings();
            settings.AssemblyReferences.Add(typeof(Application).Assembly.FullName);
            settings.AssemblyReferences.Add(typeof(EditorApplication).Assembly.FullName);
            settings.AssemblyReferences.Add(typeof(SBUniverse).Assembly.FullName);
            var printer = new ConsoleReportPrinter(new UnityMessageReporter());
            var context = new CompilerContext(settings, printer);
            evaluator = new Evaluator(context);
        }

        void OnGUI()
        {
            txt = EditorGUILayout.TextArea(txt, GUILayout.ExpandHeight(true));
            if (GUILayout.Button("Execute"))
            {
                Execute(txt);
            }
        }

        Evaluator evaluator;

        void Execute(string statement)
        {
            evaluator.Run(statement);
        }

        class UnityMessageReporter : TextWriter
        {

            public override void Write(string value)
            {
                Debug.Log(value);
            }

            public override void WriteLine(string value)
            {
                Debug.Log(value);
            }

            public override Encoding Encoding
            {
                get { return Encoding.Default; }
            }
        }
    }
}
#endif