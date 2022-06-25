using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Assignement.Pages;

public class Index_Tests : AssignementWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
