using System;
using System.Reflection;
using System.Diagnostics;

namespace BinAff.Utility.Log
{

    public class CallingMethod
    {

        public CallingMethod(Type ignoreType)
        {
            this.IgnoreType = ignoreType;
            this.Initialize();
        }

        /// <summary>
        /// Type that will be ignored.
        /// </summary>
        public Type IgnoreType { get; private set; }

        /// <summary>
        /// Calling method.
        /// </summary>
        public MethodBase Method { get; private set; }

        /// <summary>
        /// Full name of this method, with namespace.
        /// </summary>
        public String MethodNameFull { get; private set; }

        /// <summary>
        /// Name of this method.
        /// </summary>
        public String MethodName { get; private set; }

        /// <summary>
        /// Line number in the file that called the method.
        /// </summary>
        public Int32 LineNumber { get; private set; }

        /// <summary>
        /// Namespace containing the object containing this method.
        /// </summary>
        public String Namespace
        {
            get
            {
                return Type == null ? null : this.Type.Namespace;
            }
        }

        /// <summary>
        /// Name of the return type.
        /// </summary>
        public String ReturnName { get; private set; }

        /// <summary>
        /// Full method signature, file and line number.
        /// </summary>
        public String Text { get; private set; }

        /// <summary>
        /// Full name of the type that contains this method,
        /// including the namespace.
        /// </summary>
        public String TypeNameFull { get; private set; }

        /// <summary>
        /// Name of the type that contains this method,
        /// not including the namespace.
        /// </summary>
        public String TypeName { get; private set; }

        /// <summary>
        /// Type that contains this method.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Initializes the calling method information.
        /// </summary>
        private void Initialize()
        {
            //METHOD BASE
            MethodBase method = null;
            String ignoreName = this.IgnoreType == null ? null : this.IgnoreType.Name;

            //STACK TRACE
            StackFrame stackFrame = null;
            StackTrace stackTrace = new StackTrace(true);
            for (Int32 i = 0; i < stackTrace.FrameCount; i++)
            {
                StackFrame sf = stackTrace.GetFrame(i);
                method = sf.GetMethod();
                String typeName = method.ReflectedType.Name;
                if (String.Compare(typeName, ignoreName) == 0)
                {
                    stackFrame = sf;
                    break;
                }
            }

            //METHOD
            method = stackFrame.GetMethod();
            this.Method = method;
            string methodString = method.ToString();

            //TYPE
            this.Type = method.ReflectedType;
            this.TypeName = this.Type.Name;
            this.TypeNameFull = this.Type.FullName;

            //METHOD
            this.MethodName = method.Name;
            this.MethodNameFull = String.Concat(this.TypeNameFull, ".", this.MethodName);

            this.LineNumber = stackFrame.GetFileLineNumber();
        }

        public override String ToString()
        {
            return this.Text;
        }

    }

}