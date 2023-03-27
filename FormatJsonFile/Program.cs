using System.IO;
using Newtonsoft.Json;

if (args.Length != 1 && args.Length != 2)
{
    Console.WriteLine(@"Usage: <infile>
                        Usage: <infile> <outfile>");

    return;
}

bool isPathValid = File.Exists(args[0]);       
                                               
if (!isPathValid)                              
{                                              
    Console.WriteLine("File does not exist");  
    return;                                    
}                                              

if (args.Length == 1)
{
    string content = File.ReadAllText(args[0]);

    string formattedJsonString = string.Empty;
    
    try
    {
        formattedJsonString = JsonConvert.SerializeObject(
            JsonConvert.DeserializeObject(content), Formatting.Indented);
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
        return;
    }
    
    Console.WriteLine(formattedJsonString);
    return;
}

bool isOutPathValid = File.Exists(args[1]);

if (!isOutPathValid)
{
    Console.WriteLine("File does not exist");
    return;
}

FormatAndWrite(args);

void FormatAndWrite(string[] args)
{
    string content = File.ReadAllText(args[0]);
    
    string formattedJsonString = string.Empty;
    try                                                                        
    {                                                                          
        formattedJsonString = JsonConvert.SerializeObject(                     
            JsonConvert.DeserializeObject(content), Formatting.Indented);      
    }                                                                          
    catch (Exception exception)                                                
    {                                                                          
        Console.WriteLine(exception.Message);                                  
        return;                                                                
    }
    
    File.WriteAllText(args[1], formattedJsonString);
}