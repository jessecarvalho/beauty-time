using System.Numerics;
using Core.Enums;

namespace Application.DTOs;

public record EstablishmentRequestDto
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Cover { get; set; }
    public string Permalink { get; set; }
    public string Address { get; set; }
    public string TelephoneNumber { get; set; }
    public int Rating { get; set; }
    public bool HasWifi { get; set; }
    public bool AccessibleForDisabledPeople { get; set; }
    public bool HasParkPlace { get; set; }
    public GenderEnum AcceptGender { get; set; }
    public bool AcceptCreditCard { get; set; }
    public bool AcceptPix { get; set; }
    public ActiveEnum Active { get; set; }
}