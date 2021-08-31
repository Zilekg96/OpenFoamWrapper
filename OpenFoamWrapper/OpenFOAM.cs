using log4net;
using OpenFoamWrapper.System;
using System;
using System.IO;
using System.Reflection;

namespace OpenFoamWrapper
{
    public class OpenFOAM
    {
        ILog Log;
        private string modelPath { get; set; }
        public Control simulationControl { get; set; }

        public OpenFOAM()
        {
            this.Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void LoadModel(string modelPath)
        {
            this.modelPath = modelPath;

            string systemFolderPath = Path.Combine(this.modelPath, "system");

            if (Directory.Exists(systemFolderPath))
            {
                this.simulationControl = new Control(systemFolderPath, this.Log);
            }

            else
            {
                this.Log.Fatal("Case doesn't contain folder system!");
                throw new Exception("Case doesn't contain folder system!");
            }

            string constantFolderPath = Path.Combine(this.modelPath, "constant");
            
            if (Directory.Exists(constantFolderPath))
            {
                this.simulationControl = new Control(systemFolderPath, this.Log);
            }

            else
            {
                this.Log.Fatal("Case doesn't contain folder constant!");
                throw new Exception("Case doesn't contain folder constant!");
            }

            string initialStateFolderPath = Path.Combine(this.modelPath, "0");
        }
    }
}
