using Identity.Task2;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Identity_Task2;

public class RoleAttribute : TypeFilterAttribute
{
    public RoleAttribute(string role) : base(typeof(AuthAtribute))
    {
        Arguments = new object[] { role };
    }
}
