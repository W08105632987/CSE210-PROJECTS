using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        // Create a list for videos
        List<Video> videos = new List<Video>();

        // ------------------- Video 1 -------------------
        Video vid1 = new Video();
        vid1.Title = "Learn C# in 10 Minutes";
        vid1.Author = "Tech Academy";
        vid1.LengthSeconds = 600;

        vid1.AddComment(new Comment("Alice", "Great explanation!"));
        vid1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        vid1.AddComment(new Comment("Chris", "I finally understand classes!"));

        videos.Add(vid1);

        // ------------------- Video 2 -------------------
        Video vid2 = new Video();
        vid2.Title = "How to Cook Jollof Rice";
        vid2.Author = "Naija Kitchen";
        vid2.LengthSeconds = 840;

        vid2.AddComment(new Comment("David", "Looks delicious!"));
        vid2.AddComment(new Comment("Ella", "I tried it and it tasted amazing."));
        vid2.AddComment(new Comment("Frank", "Please make a fried rice tutorial!"));

        videos.Add(vid2);

        // ------------------- Video 3 -------------------
        Video vid3 = new Video();
        vid3.Title = "The Future of AI";
        vid3.Author = "TechWorld";
        vid3.LengthSeconds = 420;

        vid3.AddComment(new Comment("Grace", "This is scary and exciting!"));
        vid3.AddComment(new Comment("Henry", "AI will change everything."));
        vid3.AddComment(new Comment("Ivy", "Very informative video."));

        videos.Add(vid3);

        // ------------------- Displaying all videos -------------------
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }

    }
}