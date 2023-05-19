namespace Online_Shopping.Helpers
{
    public static class Helper
    {

        public static string AddPhoto(IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imges");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = file.FileName + fileInfo.Extension;
           

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

    }
}
