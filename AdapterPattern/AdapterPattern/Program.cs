using AdapterPattern.Classes;
using AdapterPattern.Interfaces;

IRenewedMixture new_mixture = new NewMixture();
IMixture adapter = new AdapterToRenewedMixture(new_mixture);
Serum serum = new Serum(adapter);
serum.SerumMixture();