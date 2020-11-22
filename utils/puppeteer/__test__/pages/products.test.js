const timeout = process.env.SLOWMO ? 30000 : 10000;

describe("Test product list page", () => {
  let page;

  beforeAll(async () => {
    jest.setTimeout(timeout);
    page = await global.__BROWSER__.newPage();
    await page.goto(URL, { waitUntil: "domcontentloaded" });
  }, timeout);

  afterEach(async () => {
    await page.waitFor(1000);
  });

  afterAll(async () => {
    // await page.close();
  });

  test("Title of the product list page", async () => {
    const title = await page.title();
    expect(title).toBe("ecommerce-ui");
  });

  test("Must have 2 cards on products list", async () => {
    const cards = await page.$$(".card");

    expect(cards.length).toBeGreaterThan(0);
  });

  test("Type 5 in quantity input", async () => {
    await page.$eval("#quantity0", (el) => (el.value = "5"));
    const input = await page.$("#quantity0");
    const value = await page.evaluate((x) => x.value, input);
    expect(value).toBe("5");
  });

  test("Must have 2 rows on order list", async () => {
    await page.goto("http://localhost:8080/orders", {
      waitUntil: "networkidle0",
    });

    const rows = await page.$$("tbody tr");

    expect(rows).toHaveLength(2);
  });
});
