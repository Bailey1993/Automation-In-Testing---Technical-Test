using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace Playwright.Tests;
public static class TestHelper
{
    public static async Task BookNow(IPage page)
    {
        await page.GetByRole(AriaRole.Link, new() { NameString = "Book Now" }).ClickAsync();

    }
    public static async Task CheckAvailability(IPage page)
    {
        await page.Locator("input[type=\"text\"]").First.ClickAsync();
        await page.GetByRole(AriaRole.Option, new() { NameString = "Choose Thursday, 31 July 2025" }).ClickAsync();
        await page.Locator("input[type=\"text\"]").Nth(1).ClickAsync();
        await page.GetByRole(AriaRole.Option, new() { NameString = "Choose Saturday, 2 August 2025" }).ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { NameString = "Check Availability" }).ClickAsync();
    }

    public static  async Task SelectSingleRoom(IPage page)
    {
        await page.GetByRole(AriaRole.Link, new() { NameString = "Book now" }).Nth(1).ClickAsync();
        await Expect(page.GetByText("Single Room", new() { Exact = true })).ToBeVisibleAsync();

    }

    public static async Task SelectDoubleRoom(IPage page)
    {
        await page.GetByRole(AriaRole.Link, new() { NameString = "Book now" }).Nth(2).ClickAsync();
        await page.GetByRole(AriaRole.Heading, new() { NameString = "Double Room" }).ClickAsync();
    }

    public static async Task SelectSuiteRoom(IPage page)
    {
        await page.GetByRole(AriaRole.Link, new() { NameString = "Book now" }).Nth(3).ClickAsync();
        await page.GetByRole(AriaRole.Heading, new() { NameString = "Suite Room" }).ClickAsync();
    }

    public static async Task BookRoom(IPage page, string firstName, string lastName, string email, string phoneNumber)
    {
        await page.GetByRole(AriaRole.Button, new() { NameString = "Reserve Now" }).ClickAsync();
        await page.GetByPlaceholder("Firstname").FillAsync(firstName);
        await page.GetByPlaceholder("Lastname").FillAsync(lastName);
        await page.GetByPlaceholder("Email").FillAsync(email);
        await page.GetByPlaceholder("Phone").FillAsync(phoneNumber);
        await page.GetByRole(AriaRole.Button, new() { NameString = "Reserve Now" }).ClickAsync();
    }
    public static async Task ContactUsInformation(IPage page, string firstName, string lastName, string phoneNumber)
    {
        await page.GetByTestId("ContactName").FillAsync(firstName);
        await page.GetByTestId("ContactEmail").FillAsync(lastName);
        await page.GetByTestId("ContactPhone").FillAsync(phoneNumber);
        await page.GetByTestId("ContactSubject").FillAsync("This is a test message");
        await page.GetByTestId("ContactDescription").FillAsync("This is a test message for automation");
        await page.GetByRole(AriaRole.Button, new() { NameString = "Submit" }).ClickAsync();
    }
}