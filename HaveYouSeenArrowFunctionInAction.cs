using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCompilation
{
    internal static class HaveYouSeenArrowFunctionInAction
    {
        public static bool IsDocument(this string path) => FileCategorySets.Documents.Contains(Path.GetExtension(path).ToLower());
        public static bool IsImage(this string path) => FileCategorySets.Images.Contains(Path.GetExtension(path).ToLower());
        public static bool IsZipRar(this string path) => FileCategorySets.zipRar.Contains(Path.GetExtension(path).ToLower());
        public static bool IsAnyAllowed(this string path) => FileCategorySets.AllAllowed.Contains(Path.GetExtension(path).ToLower());
        public static bool IsGroupCatFile(this string path) => FileCategorySets.GroupCatServiceFiles.Contains(Path.GetExtension(path).ToLower());
        public static bool IsVideo(this string path) => FileCategorySets.Video.Contains(Path.GetExtension(path).ToLower());
        public static bool IsExcelFile(this string path) => FileCategorySets.ExcelFile.Contains(Path.GetExtension(path).ToLower());
        public static bool IsHot(this int number) => number == 69;
    }

    public static class FileCategorySets
    {
        public static readonly HashSet<string> GroupCatServiceFiles = new() {
            ".GMUVS",".sql"
        };

        public static readonly HashSet<string> ExcelFile = new() {
            ".xls", ".xlsx"
        };

        public static readonly HashSet<string> Documents = new() {
            ".html", ".txt", ".docx", ".pdf", ".xls", ".xlsx"
        };

        public static readonly HashSet<string> DataFiles = new() {
            ".csv"
        };

        public static readonly HashSet<string> Scripts = new() {
            ".py"
        };

        public static readonly HashSet<string> Images = new() {
            ".png", ".jpg", ".jpeg", ".gif"
        };

        public static readonly HashSet<string> Video = new() {
            ".mp4"
        };

        public static readonly HashSet<string> zipRar = new() {
            ".zip", ".rar"
        };

        public static readonly HashSet<string> Reports = new() {
            ".trdx"
        };

        // All combined (for "any" check)
        public static readonly HashSet<string> AllAllowed = new() {
            ".html", ".py", ".csv", ".txt", ".docx", ".pdf",
            ".xls", ".xlsx", ".png", ".jpg", ".jpeg", ".gif",
            ".mp4", ".zip", ".rar", ".trdx"
        };
    }
}
