declare var DotNet: any;

// tslint:disable-next-line: interface-name
interface Window {
  CurrieTechnologies: any;
}

// tslint:disable-next-line: interface-name
interface PublicKeyCredential {
  getClientExtensionResults: () => ArrayBuffer;
}

// tslint:disable-next-line: interface-name
interface PublicKeyCredentialParameters {
  type: "public-key" | "password" | "federated";
}

// tslint:disable-next-line: interface-name
interface PublicKeyCredentialDescriptor {
  type: "public-key" | "password" | "federated";
}

// tslint:disable-next-line: interface-name
interface AuthenticatorSelectionCriteria {
  userVerification: "required" | "preferred" | "discouraged" | undefined;
}

const namespace: string = "CurrieTechnologies.Blazor.WebAuthentication";

const publicKeyCredentials: Map<string, PublicKeyCredential> = new Map<
  string,
  PublicKeyCredential
>();

function base64ToUintArray(base64: string) {
  const binaryString = window.atob(base64);
  const len = binaryString.length;
  const bytes = new Uint8Array(len);
  for (let i = 0; i < len; i++) {
    bytes[i] = binaryString.charCodeAt(i);
  }
  return bytes;
}

function getCredentialTransportType(input: number): AuthenticatorTransport {
  switch (input) {
    case 0:
    default:
      return "usb";
    case 1:
      return "nfc";
    case 2:
      return "ble";
    case 3:
      return "internal";
  }
}

function getCredentialType(
  input: number,
): "public-key" | "password" | "federated" {
  switch (input) {
    case 0:
    default:
      return "public-key";
    case 1:
      return "password";
    case 2:
      return "federated";
  }
}

function getUserVerificationType(
  input: number,
): "required" | "preferred" | "discouraged" | undefined {
  if (input == null) {
    return undefined;
  }

  switch (input) {
    case 0:
    default:
      return "required";
    case 1:
      return "preferred";
    case 2:
      return "discouraged";
  }
}

function getAuthenticatorAttachmentType(
  input: number,
): "platform" | "cross-platform" | undefined {
  if (input == null) {
    return undefined;
  }

  switch (input) {
    case 0:
    default:
      return "platform";
    case 1:
      return "cross-platform";
  }
}

function getAttestationType(
  input: number,
): "none" | "indirect" | "direct" | undefined {
  if (input == null) {
    return undefined;
  }

  switch (input) {
    case 0:
    default:
      return "none";
    case 1:
      return "indirect";
    case 2:
      return "direct";
  }
}

function formatPublicKeyCredentialCreationOptions(
  input: PublicKeyCredentialCreationOptions,
): PublicKeyCredentialCreationOptions {
  input.attestation = getAttestationType((input.attestation as any) as number);
  input.pubKeyCredParams = input.pubKeyCredParams.map((pkcp) => ({
    alg: pkcp.alg,
    type: getCredentialType((pkcp as any) as number),
  }));

  if (input.authenticatorSelection) {
    input.authenticatorSelection.authenticatorAttachment = getAuthenticatorAttachmentType(
      (input.authenticatorSelection.authenticatorAttachment as any) as number,
    );

    input.authenticatorSelection.userVerification = getUserVerificationType(
      (input.authenticatorSelection.userVerification as any) as number,
    );
  }

  if (input.excludeCredentials) {
    input.excludeCredentials = input.excludeCredentials.map((ec) => ({
      id: ec.id,
      transports: ec.transports
        ? ec.transports.map((t) =>
            getCredentialTransportType((t as any) as number),
          )
        : undefined,
      type: getCredentialType((ec.type as any) as number),
    }));
  }

  input.challenge = base64ToUintArray((input.challenge as any) as string);

  input.user.id = base64ToUintArray((input.user.id as any) as string);
  removeNulls(input);
  return input;
}

function removeNulls(obj: any) {
  const isArray = obj instanceof Array;
  for (const k in obj) {
    if (obj[k] === null) {
      isArray ? obj.splice(k, 1) : delete obj[k];
    } else if (typeof obj[k] === "object") {
      removeNulls(obj[k]);
    }
  }
}

function completeCreatePublicKey(
  requestId: string,
  credential: PublicKeyCredential,
) {
  DotNet.invokeMethodAsync(
    namespace,
    "CompleteCreatePublicKey",
    requestId,
    credential,
  );
}

window.CurrieTechnologies = window.CurrieTechnologies || {};
window.CurrieTechnologies.Blazor = window.CurrieTechnologies.Blazor || {};
window.CurrieTechnologies.Blazor.WebAuthentication =
  window.CurrieTechnologies.Blazor.WebAuthentication || {};
window.CurrieTechnologies.Blazor.WebAuthentication.PublicKeyCredential =
  window.CurrieTechnologies.Blazor.WebAuthentication.PublicKeyCredential || {};

window.CurrieTechnologies.Blazor.WebAuthentication.CreatePublicKey = async (
  requestId: string,
  options: PublicKeyCredentialCreationOptions,
  domId: string,
) => {
  const betterOptions = formatPublicKeyCredentialCreationOptions(options);
  const credential = (await (window.navigator
    .credentials as CredentialsContainer).create({
    publicKey: betterOptions,
  })) as PublicKeyCredential;
  publicKeyCredentials.set(domId, credential);
  completeCreatePublicKey(requestId, credential);
};

window.CurrieTechnologies.Blazor.WebAuthentication.PublicKeyCredential.GetClientExtensionResults = (
  domId: string,
) => {
  const credential = publicKeyCredentials.get(domId);
  if (credential === undefined) {
    return null;
  }
  return credential.getClientExtensionResults();
};
