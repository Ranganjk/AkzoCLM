<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);

    }

    static void RegisterRoutes(RouteCollection routes)
    {
         
               
        System.Web.Routing.RouteTable.Routes.Add("Any Description1",
            new System.Web.Routing.Route("LevelSA", new
                              PageRouteHandler("~/PreviewLevelSAdmin.aspx")));

         System.Web.Routing.RouteTable.Routes.Add("Any Description2",
               new System.Web.Routing.Route("LevelS", new
                                 PageRouteHandler("~/PreviewLevelS.aspx")));

          System.Web.Routing.RouteTable.Routes.Add("Any Description3",
               new System.Web.Routing.Route("LevelQC", new
                                 PageRouteHandler("~/PreviewLevelSQC.aspx")));

         System.Web.Routing.RouteTable.Routes.Add("Any Description4",
               new System.Web.Routing.Route("ImgUpload", new
                                 PageRouteHandler("~/ImageUpload.aspx")));

          
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

</script>
