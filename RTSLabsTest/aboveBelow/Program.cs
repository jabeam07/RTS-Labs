using aboveBelow;
using System.Text.RegularExpressions;
using static System.Console;
using System.Text.Json;
using System.Text.Json.Serialization;

SelectTest();

static void SelectTest()
{
    bool dataValid = false;
    string? result = "";
    WriteLine("Which section would you like to test? AboveBelow or StringRotation?");
    do
    {

        result = ReadLine();

        dataValid = !string.IsNullOrEmpty(result);

        if (dataValid)
        {
            dataValid = (result.ToUpper() == "ABOVEBELOW") || (result.ToUpper() == "STRINGROTATION");
        }

        if (!dataValid)
        {
            WriteLine("Please enter a valid response by entering either AboveBelow or StringRotation.");
        }

    } while (!dataValid);

    WriteLine();

    switch (result.ToUpper())
    {
        case "ABOVEBELOW":
            AboveBelowTest();
            break;
        case "STRINGROTATION":
            RotateStringTest();
            break;
    }
}

static void RotateStringTest()
{
    bool dataValid = false;
    string? inputString = "";
    string? rotationCount = "";

    WriteLine("Enter a string with at least two characters & has at least one non-space character:");

    do
    {
        inputString = ReadLine();

        dataValid = !string.IsNullOrWhiteSpace(inputString);

        if (!dataValid)
        {
            WriteLine("Please enter a string with at least two characters & one non-space character.");
        }

    } while (!dataValid);

    WriteLine("Enter a positive integer for rotation count:");
    dataValid = false;

    do
    {
       
        rotationCount = ReadLine();
        dataValid = !string.IsNullOrWhiteSpace(rotationCount);

        if (dataValid)
        {
            int numberValue = 0;
            dataValid = int.TryParse(rotationCount, out numberValue);

            if (dataValid)
            {
                dataValid = (numberValue > 0);
            }
        }

        if (!dataValid)
        {
            WriteLine("Rotation count must be a valid integer & a number greater than 0:");
        }

    } while (!dataValid);

    WriteLine($"New String: {RTSLabsTestClass.RotateString(inputString, int.Parse(rotationCount))}");
    WriteLine();
    SelectTest();
}

static void AboveBelowTest()
{
    WriteLine("Please enter a comma-delimited list of integers:");
    bool dataValid = false;

    string? result = null;
    int[]? enteredList = null;

    do
    {
        try
        {
            result = ReadLine();

            //make sure it's not null.
            dataValid = !string.IsNullOrEmpty(result);

            if (dataValid)
            {
                //removes non-numeric characters
                Regex r = new Regex("[^0-9,]", RegexOptions.IgnoreCase);
                result = r.Replace(result, "");

                //make sure the updated result string isn't null or empty.
                dataValid = !string.IsNullOrEmpty(result);

                if (dataValid)
                {
                    string[] resultSplit = result.Split(',');

                    enteredList = Array.ConvertAll(resultSplit, int.Parse);
                }
            }
        }
        catch (Exception)
        {
            dataValid = false;
        }



        if (!dataValid)
        {
            WriteLine("Please enter a valid list of integers:");
        }

    } while (!dataValid);

    dataValid = false;

    WriteLine("Please enter an integer for comparison:");
    int compareNum = 0;
    do
    {
        try
        {
            result = ReadLine();

            dataValid = int.TryParse(result, out compareNum);
        }
        catch (Exception)
        {

            dataValid = false;
        }

        if (!dataValid)
        {
            compareNum = 0;
            WriteLine("Please enter a valid integer:");
        }

    } while (!dataValid);

    AboveBelowResult abResult = RTSLabsTestClass.CompareInts(enteredList, compareNum);

    WriteLine($"output: {JsonSerializer.Serialize(abResult)}");

    WriteLine();
    SelectTest();
}