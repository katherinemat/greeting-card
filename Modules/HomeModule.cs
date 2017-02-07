using Nancy;
using FriendLetter.Objects;

namespace FriendLetter
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/hello"] = _ => "Hello friend!";
      Get["/favorite_photos"] = _ => View["favorite_photos.cshtml"];
      Get["/goodbye"] = _ => "Goodbye friend!";
      Get["/greeting-card"] = _ => {
          LetterVariables myLetterVariables = new LetterVariables();
          myLetterVariables.SetRecipient(Request.Query["recipient"]);
          myLetterVariables.SetSender(Request.Query["sender"]);
          return View["hello.cshtml", myLetterVariables];
        };
      Get["/"] = _ => {
        return View["form.cshtml"];
      };
    }
  }
}
