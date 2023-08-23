using Server.Services;
using System.Net;
using System.Text;

var port = 8080;
var host = $"http://localhost:{port}/";
var listener = new HttpListener();

listener.Prefixes.Add(host);
listener.Start();


Console.WriteLine("Listening for requests...");

//while (true)
//{
//    var context = await listener.GetContextAsync();
//    var request = context.Request;
//    var response = context.Response;

//    if (request.HttpMethod == "GET" && request.RawUrl.StartsWith("/api/user/checkuser"))
//    {
//        var username = request.QueryString.Get("username");
//        var userExists = DbManageService.CheckUserExists(username);

//        var responseText = userExists ? "true" : "false";
//        var responseBytes = System.Text.Encoding.UTF8.GetBytes(responseText);

//        response.ContentType = "text/plain";
//        response.ContentLength64 = responseBytes.Length;
//        await response.OutputStream.WriteAsync(responseBytes, 0, responseBytes.Length);
//        response.OutputStream.Close();
//    }
//    else
//    {
//        response.StatusCode = (int)HttpStatusCode.NotFound;
//        response.Close();
//    }
//}


while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;

    string responseString = ProcessRequest(request);
    byte[] buffer = Encoding.UTF8.GetBytes(responseString);

    response.ContentLength64 = buffer.Length;
    var output = response.OutputStream;
    output.Write(buffer, 0, buffer.Length);
    output.Close();
}

static string ProcessRequest(HttpListenerRequest request)
{
    string path = request.Url.LocalPath.ToLower();
    string query = request.Url.Query;

    if (path == "/checkuserexists" && request.HttpMethod == "GET")
    {
        string username = request.QueryString.Get("username");
        bool userExists = DbManageService.CheckUserExists(username);
        return userExists.ToString();
    }
    else if (path == "/getuser" && request.HttpMethod == "GET")
    {
        string username = request.QueryString.Get("username");
        string password = request.QueryString.Get("password");
        string userData = DbManageService.GetUser(username, password);

        if (userData != null)
        {
            return userData;
        }
        else
        {
            return "User not found";
        }
    }
    else if (path == "/adduser" && request.HttpMethod == "POST")
    {
        string data = ReadRequestBody(request);
        bool userAdded = DbManageService.AddUser(data);
        return userAdded.ToString();
    }
    else if (path == "/updateuser" && request.HttpMethod == "POST")
    {
        string data = ReadRequestBody(request);
        bool userUpdated = DbManageService.UpdateUser(data);
        return userUpdated.ToString();
    }
    else
    {
        return "Incorrect query";
    }
}

static string ReadRequestBody(HttpListenerRequest request)
{
    using (var body = request.InputStream)
    {
        using (var reader = new System.IO.StreamReader(body, request.ContentEncoding))
        {
            string requestBody = reader.ReadToEnd();
            return requestBody ?? string.Empty;
        }
    }
}

