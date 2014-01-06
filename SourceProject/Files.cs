using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


public class Files {

    private const string path = @"Saves";

    public static List<String> getSaves() {

        if(!Directory.Exists(path))
            return null;

        List<String> files = new List<String>(Directory.GetFiles(path));
        files.RemoveAll(f => Path.GetExtension(f) != ".small");
        files.ForEach(f => Path.GetFileNameWithoutExtension(f));

        return files;
    }

    // load or save the file
    public static void saveHandle(string fileName, bool load) {

        // If save directory does not exist.
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);

        BinaryFormatter formatter = new BinaryFormatter();
        FileAccess fa = (load) ? FileAccess.Read : FileAccess.Write;
        string fullPath = path + Path.DirectorySeparatorChar + fileName + ".small";

        Stream fs = new FileStream(fullPath, FileMode.OpenOrCreate, fa);

        try {
            if(load)
                Game.instance = ((Game)formatter.Deserialize(fs));
            else
                formatter.Serialize(fs, Game.instance);
        } catch(SerializationException e) {
            Console.WriteLine("Serialization failed. Reason: " + e.Message);
        } finally {
            fs.Close();
        }

    }

}

