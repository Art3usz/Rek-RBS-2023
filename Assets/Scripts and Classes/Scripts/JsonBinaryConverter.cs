using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using UnityEngine;

public static class JsonBinaryConverter {
    //Serializing JSON Data into Binary Form

    //source https://www.dotnetcurry.com/csharp/1279/serialize-json-data-binary
    static MemoryStream JBConverter (string json) {
        //1. Deserialize into JSON object form.
        var jsonObject = JsonConvert.DeserializeObject (json);
        //3. Declare an instance of JsonSerializer.
        JsonSerializer jsonSerializer = new JsonSerializer ();
        //4. Since we need to represent the data in binary format we need MemoryStream object.
        System.IO.MemoryStream objBsonMemoryStream = new MemoryStream ();
        //5. An instance of BsonWriter class. This represents a writer that provide fast, non-cached, forward-only way of generating JSON data.
        BsonWriter bsonWriterObject = new BsonWriter (objBsonMemoryStream);
        //6. Serialize the JSON data into BSON.
        jsonSerializer.Serialize (bsonWriterObject, jsonObject);
        //7. Return object after convertion
        return objBsonMemoryStream;
    }
}