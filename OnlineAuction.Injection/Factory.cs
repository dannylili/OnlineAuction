using Spring.Context;
using Spring.Context.Support;
namespace OnlineAuction.Injection
{
    public static class Factory
    {
        #region Field

        public static IApplicationContext applicationcontext;

        #endregion

        #region publick Methods

        public static TType Get<TType>(string token) where TType : class
        {
            return (TType)ApplicationContext.GetObject(token);
        }

        public static TType get<TType>(string token, object[] arguments) where TType : class
        {
            return (TType)ApplicationContext.GetObject(token, arguments);
        }

        public static bool IsDefined(string token)
        {
            return ApplicationContext.ContainsObjectDefinition(token);
        }

        #endregion

        #region public Properties

        public static string ApplicationContextName { get; set; }

        #endregion

        #region Public Properties

        public static IApplicationContext ApplicationContext
        {
            get
            {
                if (applicationcontext == null || applicationcontext.Name != ApplicationContextName)
                {
                    applicationcontext = string.IsNullOrEmpty(ApplicationContextName)
                        ? ContextRegistry.GetContext()
                        : ContextRegistry.GetContext(ApplicationContextName);
                }
                return applicationcontext;
            }
        }

        #endregion
    }
}
