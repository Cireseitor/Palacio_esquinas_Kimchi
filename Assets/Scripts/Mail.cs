using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class Mail : MonoBehaviour {

    public GameObject panelEnviado;
    public Text Email;

    public void sendEmail() {
        try {
            if (Email.GetComponent<Text>().text.Length > 0 && Email.GetComponent<Text>().text.Contains("@")) {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(Email.GetComponent<Text>().text);
                mail.To.Add("imascono@gmail.com");
                mail.Subject = "Contacto app imascono";
                mail.Body = "1Comparte tu experiencia en RRSS con el hashtag #TRUexperience     " +
                    "<html><head><meta charset = 'utf-8' >< title > Mi pagina de prueba </ title > </ head ><body><img src = 'images/firefox-icon.png' alt = 'Mi imagen de prueba'></body></html>";

                SmtpClient smtpServer = new SmtpClient("mail.chromville.com");
                smtpServer.Port = 25;
                smtpServer.Credentials = new NetworkCredential("noreply@chromville.com", "Imascono2016") as ICredentialsByHost;
                smtpServer.EnableSsl = false;
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpServer.Send(mail);
                panelEnviado.transform.GetChild(0).GetComponent<Text>().text = "Thanks for contacting us.\n\nWe will get back to you as soon as possible.";
                panelEnviado.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
                StartCoroutine(enviado());
            }
            else {
                panelEnviado.transform.GetChild(0).GetComponent<Text>().text = "Please fill in the fields marked *";
                panelEnviado.SetActive(true);
                StartCoroutine(enviado());
            }
        }
        catch (Exception e) {
            Debug.Log(e.Data);
            Debug.Log(e.Message);
            panelEnviado.transform.GetChild(0).GetComponent<Text>().text = "Delivery has failed. \n\nPlease, check your internet connection and try it again.";
            panelEnviado.SetActive(true);
            StartCoroutine(enviado());
        }

    }

    IEnumerator enviado() {
        yield return new WaitForSeconds(2);
        panelEnviado.SetActive(false);
    }
}
