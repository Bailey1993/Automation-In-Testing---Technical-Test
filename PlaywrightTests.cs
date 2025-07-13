using Microsoft.Playwright;

namespace Playwright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : BasePlaywrightTest
{
    private string? firstName = "John";
    private string? lastName = "Smith";
    private string? email = "johnsmith@google.com";
    private string? phoneNumber = "07111222333";

    [Test]
    public async Task BookSingleRoom()
    {
        await TestHelper.BookNow(Page);

        await TestHelper.CheckAvailability(Page);

        await TestHelper.SelectSingleRoom(Page);

        await TestHelper.BookRoom(Page, firstName, lastName, email, phoneNumber);
    }
    [Test]
    public async Task BookDoubleRoom()
    {
        await TestHelper.BookNow(Page);

        await TestHelper.CheckAvailability(Page);

        await TestHelper.SelectDoubleRoom(Page);

        await TestHelper.BookRoom(Page, firstName, lastName, email, phoneNumber);
    }
    [Test]
    public async Task BookSuiteRoom()
    {
        await TestHelper.BookNow(Page);

        await TestHelper.CheckAvailability(Page);

        await TestHelper.SelectSuiteRoom(Page);

        await TestHelper.BookRoom(Page, firstName, lastName, email, phoneNumber);
    }
    [Test]
    public async Task ContactUs()
    {
        await TestHelper.ContactUsInformation(Page,firstName, lastName, email);
    }
}
