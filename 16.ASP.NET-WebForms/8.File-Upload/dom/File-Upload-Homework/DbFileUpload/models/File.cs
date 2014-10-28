namespace DbFileUpload.models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UploadedFile
    {
        public int Id { get; set; }

        [Required]
        public byte[] Data { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}