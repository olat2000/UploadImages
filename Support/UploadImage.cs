namespace ImageUploadAuto.Support
{
    public class UploadImage
    {
        #region Start of Method
        public static async Task FileUpload(string scriptName, string fileName)
        {
            await Task.Delay(3000); 

            var script = Path.Combine(Directory.GetCurrentDirectory(), "C:\\ImageUploadAuto\\TestData", scriptName);
            var fileToUpload = Path.Combine(Directory.GetCurrentDirectory(), "C:\\ImageUploadAuto\\TestData", fileName);
            //var fileToUpload = Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);
           
            var processStartInfo = new ProcessStartInfo()
            {
                FileName = script,
                Arguments = fileToUpload
            };
            using (var process = Process.Start(processStartInfo))
            {
                await process!.WaitForExitAsync();
            }
            await Task.Delay(5000);
        }
    }
    #endregion End of method
}
