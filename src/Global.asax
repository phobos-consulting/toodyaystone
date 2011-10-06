<%@ Application Language="C#" Inherits="N2.Web.Global" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Security.Principal" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
            string[] roles = id.Ticket.UserData.Split(new char[] { '|' });
            GenericPrincipal principal = new GenericPrincipal(HttpContext.Current.User.Identity, roles);

            Context.User = principal;
        }
    }
       
</script>
