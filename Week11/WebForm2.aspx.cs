using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Text;
namespace Week11
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://itunes.apple.com/search?term=" + tbxSearch.Text+"&media="+typeDdl.SelectedValue);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();
            response.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(iTunesResults));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            iTunesResults iTunesResults = (iTunesResults)js.ReadObject(stream);
            Response.Write("<table border ='1'><th>Information</th><th>More Information</th>");
            foreach (Result r in iTunesResults.Results)
            {
                
                if (typeDdl.SelectedValue.Equals("movie"))
                {
                    Response.Write("<tr><td>");
                    Response.Write("<a href='WebForm3.aspx'>" + r.TrackName + "</a><br/>" + r.ContentAdvisoryRating + "<br/>");
                    Response.Write("<img src ='" + r.ArtworkUrl60 + "'/>");
                    Response.Write("</td>");
                    Response.Write("<td>");
                    Response.Write(r.TrackName + "<br/>" + r.LongDescription + "<br/>" +r.PrimaryGenreName+"<br/>"+r.TrackHdPrice);
                    Response.Write("</td></tr>");

                }
                else if (typeDdl.SelectedValue.Equals("music"))
                {
                    Response.Write("<tr><td>");
                    Response.Write("<a href='WebForm3.aspx'>"+r.TrackName + "</a><br/>" + r.CollectionName + "<br/>");
                    Response.Write("<img src ='" + r.ArtworkUrl60 + "'/>");
                    Response.Write("</td>");
                    Response.Write("<td>");
                    Response.Write(r.TrackName + "<br/>" + r.ArtistName + "<br/>" + r.CollectionName + "<br/>" + r.TrackPrice + "<br/>" + r.CollectionPrice);
                    Response.Write("</td></tr>");
                }
                else if (typeDdl.SelectedValue.Equals("software"))
                {
                    Response.Write("<tr>");
                    
                    Response.Write("<td>" + r.ArtistName+"<br/>"+r.price+"</td>");
                    Response.Write("<td>Artist: " + r.ArtistName + "<br/><br/>Supported Devices: ");
                    foreach(var i in r.supportedDevices) {
                        Response.Write(i +", ");
                            
                    }
                    Response.Write("<br/><br/>Description: "+r.description + "<br/><br/>Genre: ");
                    foreach (var j in r.genres) {
                        Response.Write(j + ", ");
                    }
                    Response.Write("<br/><img height = '150' width='84'src ='" + r.screenshotUrls[0]+"'/>&nbsp;" +"<img height='150' width='84' src='"+r.screenshotUrls[1]+"'</></td>");

                    
                }
                else
                {
                    Response.Write("Invalid");
                }
                
                
            }
            Response.Write("</table>");
            response.Close();


        }
    }
}
[DataContract]
public class Result
{

    [DataMember(Name = "wrapperType")]
    public string WrapperType { get; set; }

    [DataMember(Name = "kind")]
    public string Kind { get; set; }

    [DataMember(Name = "collectionId")]
    public int CollectionId { get; set; }

    [DataMember(Name = "trackId")]
    public int TrackId { get; set; }

    [DataMember(Name = "artistName")]
    public string ArtistName { get; set; }

    [DataMember(Name = "collectionName")]
    public string CollectionName { get; set; }

    [DataMember(Name = "trackName")]
    public string TrackName { get; set; }

    [DataMember(Name = "collectionCensoredName")]
    public string CollectionCensoredName { get; set; }

    [DataMember(Name = "trackCensoredName")]
    public string TrackCensoredName { get; set; }

    [DataMember(Name = "collectionArtistId")]
    public int CollectionArtistId { get; set; }

    [DataMember(Name = "collectionArtistViewUrl")]
    public string CollectionArtistViewUrl { get; set; }

    [DataMember(Name = "collectionViewUrl")]
    public string CollectionViewUrl { get; set; }

    [DataMember(Name = "trackViewUrl")]
    public string TrackViewUrl { get; set; }

    [DataMember(Name = "previewUrl")]
    public string PreviewUrl { get; set; }

    [DataMember(Name = "artworkUrl30")]
    public string ArtworkUrl30 { get; set; }

    [DataMember(Name = "artworkUrl60")]
    public string ArtworkUrl60 { get; set; }

    [DataMember(Name = "artworkUrl100")]
    public string ArtworkUrl100 { get; set; }

    [DataMember(Name = "collectionPrice")]
    public double CollectionPrice { get; set; }

    [DataMember(Name = "trackPrice")]
    public double TrackPrice { get; set; }

    [DataMember(Name = "trackRentalPrice")]
    public double TrackRentalPrice { get; set; }

    [DataMember(Name = "collectionHdPrice")]
    public double CollectionHdPrice { get; set; }

    [DataMember(Name = "trackHdPrice")]
    public double TrackHdPrice { get; set; }

    [DataMember(Name = "trackHdRentalPrice")]
    public double TrackHdRentalPrice { get; set; }

    //[DataMember(Name = "releaseDate")]
    //public DateTime ReleaseDate { get; set; }

    [DataMember(Name = "collectionExplicitness")]
    public string CollectionExplicitness { get; set; }

    [DataMember(Name = "trackExplicitness")]
    public string TrackExplicitness { get; set; }

    [DataMember(Name = "discCount")]
    public int DiscCount { get; set; }

    [DataMember(Name = "discNumber")]
    public int DiscNumber { get; set; }

    [DataMember(Name = "trackCount")]
    public int TrackCount { get; set; }

    [DataMember(Name = "trackNumber")]
    public int TrackNumber { get; set; }

    [DataMember(Name = "trackTimeMillis")]
    public int TrackTimeMillis { get; set; }

    [DataMember(Name = "country")]
    public string Country { get; set; }

    [DataMember(Name = "currency")]
    public string Currency { get; set; }

    [DataMember(Name = "primaryGenreName")]
    public string PrimaryGenreName { get; set; }

    [DataMember(Name = "contentAdvisoryRating")]
    public string ContentAdvisoryRating { get; set; }

    [DataMember(Name = "shortDescription")]
    public string ShortDescription { get; set; }

    [DataMember(Name = "longDescription")]
    public string LongDescription { get; set; }

    [DataMember(Name = "hasITunesExtras")]
    public bool HasITunesExtras { get; set; }

    [DataMember(Name = "artistId")]
    public int? ArtistId { get; set; }

    [DataMember(Name = "artistViewUrl")]
    public string ArtistViewUrl { get; set; }

    [DataMember(Name = "isStreamable")]
    public bool? IsStreamable { get; set; }

    [DataMember(Name = "collectionArtistName")]
    public string CollectionArtistName { get; set; }
    [DataMember(Name = "screenshotUrls")]
    public IList<string> screenshotUrls { get; set; }

    [DataMember(Name = "ipadScreenshotUrls")]
    public IList<string> ipadScreenshotUrls { get; set; }

    [DataMember(Name = "appletvScreenshotUrls")]
    public IList<object> appletvScreenshotUrls { get; set; }

    [DataMember(Name = "supportedDevices")]
    public IList<string> supportedDevices { get; set; }

    [DataMember(Name = "formattedPrice")]
    public string formattedPrice { get; set; }

    [DataMember(Name = "description")]
    public string description { get; set; }

    [DataMember(Name = "genres")]
    public IList<string> genres { get; set; }

    [DataMember(Name = "price")]
    public double price { get; set; }



}

[DataContract]
public class iTunesResults
{

    [DataMember(Name = "resultCount")]
    public int ResultCount { get; set; }

    [DataMember(Name = "results")]
    public IList<Result> Results { get; set; }
}