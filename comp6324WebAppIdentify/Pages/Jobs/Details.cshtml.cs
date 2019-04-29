using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using comp6324WebAppIdentify.Models;
using Microsoft.Azure.Devices;
using System.Text;
using System.Diagnostics;

namespace comp6324WebAppIdentify.Pages.Jobs
{
    public class DetailsModel : PageModel
    {
        private readonly comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext _context;

        public DetailsModel(comp6324WebAppIdentify.Models.comp6324WebAppIdentifyContext context)
        {
            _context = context;
        }

        public Job Job { get; set; }
        public Measurement Measurement { get; set; }
        static ServiceClient serviceClient;
        static string connectionString = "HostName=james6342iot.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=RnzkBco8VRay0qFzzsVy4GFmpQF6uTDHVJInUD7VlQ4=";
        static string TestCmdString = "TEST ON";

        public async Task<IActionResult> OnGetAsync(int? id, int? test)
        {
            if (1 == test)
            {
                TestCmdString = "TEST ON";
                Debug.WriteLine("#### Send Cloud-to-Device message test on ######\n");
                serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
                ReceiveFeedbackAsync();
                SendCloudToDeviceMessageAsync().Wait();
                Debug.WriteLine("#### Send Cloud-to-Device message OK! ######\n");
            }
            else if (2 == test)
            {
                TestCmdString = "TEST OFF";
                Debug.WriteLine("#### Send Cloud-to-Device message test off ######\n");
                serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
                ReceiveFeedbackAsync();
                SendCloudToDeviceMessageAsync().Wait();
                Debug.WriteLine("#### Send Cloud-to-Device message OK! ######\n");
            }
            else
            {
                Debug.WriteLine("#### Nothing to do here! ######");
            }

            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Job.FirstOrDefaultAsync(m => m.JobID == id);
            Measurement = await _context.Measurement.LastOrDefaultAsync(m => m.deviceID == Job.deviceID);

            if (Job == null)
            {
                return NotFound();
            }
            return Page();
        }


        private async static Task SendCloudToDeviceMessageAsync()
        {
            var commandMessage = new
             Message(Encoding.ASCII.GetBytes(TestCmdString));
            commandMessage.Ack = DeliveryAcknowledgement.Full;
            await serviceClient.SendAsync("james6342IoTGateway", commandMessage);
        }

        private async static void ReceiveFeedbackAsync()
        {
            var feedbackReceiver = serviceClient.GetFeedbackReceiver();

            Debug.WriteLine("\n#####Receiving c2d feedback from service");
            while (true)
            {
                var feedbackBatch = await feedbackReceiver.ReceiveAsync();
                if (feedbackBatch == null) continue;

                Debug.WriteLine("#########Received feedback: {0}",
                  string.Join(", ", feedbackBatch.Records.Select(f => f.StatusCode)));


                await feedbackReceiver.CompleteAsync(feedbackBatch);
            }
        }
    }
}
