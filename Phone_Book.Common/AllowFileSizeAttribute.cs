namespace Phone_Book.Common
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>  
    /// Allow file size attribute class  
    /// </summary>  
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowFileSizeAttribute : ValidationAttribute
    {
        #region Public / Protected Properties  

        /// <summary>  
        /// Gets or sets file size property. Default is 1GB (the value is in Bytes).  
        /// </summary>  
        public int FileSize { get; set; } = 1 * 1024 * 1024 * 1024;

        #endregion

        #region Is valid method  

        /// <summary>  
        /// Is valid method.  
        /// </summary>  
        /// <param name="value">Value parameter</param>  
        /// <returns>Returns - true is specify extension matches.</returns>  
        public override bool IsValid(object value)
        {
            // Initialization  
            bool isValid = true;

            // Settings.  
            int allowedFileSize = FileSize;

            // Verification.  
            if (value is IFormFile file)
            {
                // Initialization.  
                var fileSize = file.Length;

                // Settings.  
                isValid = fileSize <= allowedFileSize;

            }

            // Info  
            return isValid;
        }

        #endregion
    }
}
