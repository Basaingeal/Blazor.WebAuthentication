"use strict";

// tslint:disable-next-line: interface-name
// tslint:disable-next-line: interface-name
// tslint:disable-next-line: interface-name
// tslint:disable-next-line: interface-name
// tslint:disable-next-line: interface-name
const namespace = "CurrieTechnologies.Blazor.WebAuthentication";
const publicKeyCredentials = new Map();

function base64ToUintArray(base64) {
  const binaryString = window.atob(base64);
  const len = binaryString.length;
  const bytes = new Uint8Array(len);

  for (let i = 0; i < len; i++) {
    bytes[i] = binaryString.charCodeAt(i);
  }

  return bytes;
}

function getCredentialTransportType(input) {
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

function getCredentialType(input) {
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

function getUserVerificationType(input) {
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

function getAuthenticatorAttachmentType(input) {
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

function getAttestationType(input) {
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

function formatPublicKeyCredentialCreationOptions(input) {
  input.attestation = getAttestationType(input.attestation);
  input.pubKeyCredParams = input.pubKeyCredParams.map((pkcp) => ({
    alg: pkcp.alg,
    type: getCredentialType(pkcp),
  }));

  if (input.authenticatorSelection) {
    input.authenticatorSelection.authenticatorAttachment = getAuthenticatorAttachmentType(
      input.authenticatorSelection.authenticatorAttachment,
    );
    input.authenticatorSelection.userVerification = getUserVerificationType(
      input.authenticatorSelection.userVerification,
    );
  }

  if (input.excludeCredentials) {
    input.excludeCredentials = input.excludeCredentials.map((ec) => ({
      id: ec.id,
      transports: ec.transports
        ? ec.transports.map((t) => getCredentialTransportType(t))
        : undefined,
      type: getCredentialType(ec.type),
    }));
  }

  input.challenge = base64ToUintArray(input.challenge);
  input.user.id = base64ToUintArray(input.user.id);
  removeNulls(input);
  return input;
}

function removeNulls(obj) {
  const isArray = obj instanceof Array;

  for (const k in obj) {
    if (obj[k] === null) {
      isArray ? obj.splice(k, 1) : delete obj[k];
    } else if (typeof obj[k] === "object") {
      removeNulls(obj[k]);
    }
  }
}

function completeCreatePublicKey(requestId, credential) {
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
  requestId,
  options,
  domId,
) => {
  const betterOptions = formatPublicKeyCredentialCreationOptions(options);
  const credential = await window.navigator.credentials.create({
    publicKey: betterOptions,
  });
  publicKeyCredentials.set(domId, credential);
  completeCreatePublicKey(requestId, credential);
};

window.CurrieTechnologies.Blazor.WebAuthentication.PublicKeyCredential.GetClientExtensionResults = (
  domId,
) => {
  const credential = publicKeyCredentials.get(domId);

  if (credential === undefined) {
    return null;
  }

  return credential.getClientExtensionResults();
};
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIi4uL3NyYy9XZWJBdXRoZW50aWNhdGlvbi50cyJdLCJuYW1lcyI6WyJuYW1lc3BhY2UiLCJwdWJsaWNLZXlDcmVkZW50aWFscyIsIk1hcCIsImJhc2U2NFRvVWludEFycmF5IiwiYmFzZTY0IiwiYmluYXJ5U3RyaW5nIiwid2luZG93IiwiYXRvYiIsImxlbiIsImxlbmd0aCIsImJ5dGVzIiwiVWludDhBcnJheSIsImkiLCJjaGFyQ29kZUF0IiwiZ2V0Q3JlZGVudGlhbFRyYW5zcG9ydFR5cGUiLCJpbnB1dCIsImdldENyZWRlbnRpYWxUeXBlIiwiZ2V0VXNlclZlcmlmaWNhdGlvblR5cGUiLCJ1bmRlZmluZWQiLCJnZXRBdXRoZW50aWNhdG9yQXR0YWNobWVudFR5cGUiLCJnZXRBdHRlc3RhdGlvblR5cGUiLCJmb3JtYXRQdWJsaWNLZXlDcmVkZW50aWFsQ3JlYXRpb25PcHRpb25zIiwiYXR0ZXN0YXRpb24iLCJwdWJLZXlDcmVkUGFyYW1zIiwibWFwIiwicGtjcCIsImFsZyIsInR5cGUiLCJhdXRoZW50aWNhdG9yU2VsZWN0aW9uIiwiYXV0aGVudGljYXRvckF0dGFjaG1lbnQiLCJ1c2VyVmVyaWZpY2F0aW9uIiwiZXhjbHVkZUNyZWRlbnRpYWxzIiwiZWMiLCJpZCIsInRyYW5zcG9ydHMiLCJ0IiwiY2hhbGxlbmdlIiwidXNlciIsInJlbW92ZU51bGxzIiwib2JqIiwiaXNBcnJheSIsIkFycmF5IiwiayIsInNwbGljZSIsImNvbXBsZXRlQ3JlYXRlUHVibGljS2V5IiwicmVxdWVzdElkIiwiY3JlZGVudGlhbCIsIkRvdE5ldCIsImludm9rZU1ldGhvZEFzeW5jIiwiQ3VycmllVGVjaG5vbG9naWVzIiwiQmxhem9yIiwiV2ViQXV0aGVudGljYXRpb24iLCJQdWJsaWNLZXlDcmVkZW50aWFsIiwiQ3JlYXRlUHVibGljS2V5Iiwib3B0aW9ucyIsImRvbUlkIiwiYmV0dGVyT3B0aW9ucyIsIm5hdmlnYXRvciIsImNyZWRlbnRpYWxzIiwiY3JlYXRlIiwicHVibGljS2V5Iiwic2V0IiwiR2V0Q2xpZW50RXh0ZW5zaW9uUmVzdWx0cyIsImdldCIsImdldENsaWVudEV4dGVuc2lvblJlc3VsdHMiXSwibWFwcGluZ3MiOiI7O0FBRUE7QUFLQTtBQUtBO0FBS0E7QUFLQTtBQUtBLE1BQU1BLFNBQWlCLEdBQUcsNkNBQTFCO0FBRUEsTUFBTUMsb0JBQXNELEdBQUcsSUFBSUMsR0FBSixFQUEvRDs7QUFLQSxTQUFTQyxpQkFBVCxDQUEyQkMsTUFBM0IsRUFBMkM7QUFDekMsUUFBTUMsWUFBWSxHQUFHQyxNQUFNLENBQUNDLElBQVAsQ0FBWUgsTUFBWixDQUFyQjtBQUNBLFFBQU1JLEdBQUcsR0FBR0gsWUFBWSxDQUFDSSxNQUF6QjtBQUNBLFFBQU1DLEtBQUssR0FBRyxJQUFJQyxVQUFKLENBQWVILEdBQWYsQ0FBZDs7QUFDQSxPQUFLLElBQUlJLENBQUMsR0FBRyxDQUFiLEVBQWdCQSxDQUFDLEdBQUdKLEdBQXBCLEVBQXlCSSxDQUFDLEVBQTFCLEVBQThCO0FBQzVCRixJQUFBQSxLQUFLLENBQUNFLENBQUQsQ0FBTCxHQUFXUCxZQUFZLENBQUNRLFVBQWIsQ0FBd0JELENBQXhCLENBQVg7QUFDRDs7QUFDRCxTQUFPRixLQUFQO0FBQ0Q7O0FBRUQsU0FBU0ksMEJBQVQsQ0FBb0NDLEtBQXBDLEVBQTJFO0FBQ3pFLFVBQVFBLEtBQVI7QUFDRSxTQUFLLENBQUw7QUFDQTtBQUNFLGFBQU8sS0FBUDs7QUFDRixTQUFLLENBQUw7QUFDRSxhQUFPLEtBQVA7O0FBQ0YsU0FBSyxDQUFMO0FBQ0UsYUFBTyxLQUFQOztBQUNGLFNBQUssQ0FBTDtBQUNFLGFBQU8sVUFBUDtBQVRKO0FBV0Q7O0FBRUQsU0FBU0MsaUJBQVQsQ0FDRUQsS0FERixFQUUyQztBQUN6QyxVQUFRQSxLQUFSO0FBQ0UsU0FBSyxDQUFMO0FBQ0E7QUFDRSxhQUFPLFlBQVA7O0FBQ0YsU0FBSyxDQUFMO0FBQ0UsYUFBTyxVQUFQOztBQUNGLFNBQUssQ0FBTDtBQUNFLGFBQU8sV0FBUDtBQVBKO0FBU0Q7O0FBRUQsU0FBU0UsdUJBQVQsQ0FDRUYsS0FERixFQUV3RDtBQUN0RCxNQUFJQSxLQUFLLElBQUksSUFBYixFQUFtQjtBQUNqQixXQUFPRyxTQUFQO0FBQ0Q7O0FBRUQsVUFBUUgsS0FBUjtBQUNFLFNBQUssQ0FBTDtBQUNBO0FBQ0UsYUFBTyxVQUFQOztBQUNGLFNBQUssQ0FBTDtBQUNFLGFBQU8sV0FBUDs7QUFDRixTQUFLLENBQUw7QUFDRSxhQUFPLGFBQVA7QUFQSjtBQVNEOztBQUVELFNBQVNJLDhCQUFULENBQ0VKLEtBREYsRUFFNkM7QUFDM0MsTUFBSUEsS0FBSyxJQUFJLElBQWIsRUFBbUI7QUFDakIsV0FBT0csU0FBUDtBQUNEOztBQUVELFVBQVFILEtBQVI7QUFDRSxTQUFLLENBQUw7QUFDQTtBQUNFLGFBQU8sVUFBUDs7QUFDRixTQUFLLENBQUw7QUFDRSxhQUFPLGdCQUFQO0FBTEo7QUFPRDs7QUFFRCxTQUFTSyxrQkFBVCxDQUNFTCxLQURGLEVBRThDO0FBQzVDLE1BQUlBLEtBQUssSUFBSSxJQUFiLEVBQW1CO0FBQ2pCLFdBQU9HLFNBQVA7QUFDRDs7QUFFRCxVQUFRSCxLQUFSO0FBQ0UsU0FBSyxDQUFMO0FBQ0E7QUFDRSxhQUFPLE1BQVA7O0FBQ0YsU0FBSyxDQUFMO0FBQ0UsYUFBTyxVQUFQOztBQUNGLFNBQUssQ0FBTDtBQUNFLGFBQU8sUUFBUDtBQVBKO0FBU0Q7O0FBRUQsU0FBU00sd0NBQVQsQ0FDRU4sS0FERixFQUVzQztBQUNwQ0EsRUFBQUEsS0FBSyxDQUFDTyxXQUFOLEdBQW9CRixrQkFBa0IsQ0FBRUwsS0FBSyxDQUFDTyxXQUFSLENBQXRDO0FBQ0FQLEVBQUFBLEtBQUssQ0FBQ1EsZ0JBQU4sR0FBeUJSLEtBQUssQ0FBQ1EsZ0JBQU4sQ0FBdUJDLEdBQXZCLENBQTRCQyxJQUFELEtBQVc7QUFDN0RDLElBQUFBLEdBQUcsRUFBRUQsSUFBSSxDQUFDQyxHQURtRDtBQUU3REMsSUFBQUEsSUFBSSxFQUFFWCxpQkFBaUIsQ0FBRVMsSUFBRjtBQUZzQyxHQUFYLENBQTNCLENBQXpCOztBQUtBLE1BQUlWLEtBQUssQ0FBQ2Esc0JBQVYsRUFBa0M7QUFDaENiLElBQUFBLEtBQUssQ0FBQ2Esc0JBQU4sQ0FBNkJDLHVCQUE3QixHQUF1RFYsOEJBQThCLENBQ2xGSixLQUFLLENBQUNhLHNCQUFOLENBQTZCQyx1QkFEcUQsQ0FBckY7QUFJQWQsSUFBQUEsS0FBSyxDQUFDYSxzQkFBTixDQUE2QkUsZ0JBQTdCLEdBQWdEYix1QkFBdUIsQ0FDcEVGLEtBQUssQ0FBQ2Esc0JBQU4sQ0FBNkJFLGdCQUR1QyxDQUF2RTtBQUdEOztBQUVELE1BQUlmLEtBQUssQ0FBQ2dCLGtCQUFWLEVBQThCO0FBQzVCaEIsSUFBQUEsS0FBSyxDQUFDZ0Isa0JBQU4sR0FBMkJoQixLQUFLLENBQUNnQixrQkFBTixDQUF5QlAsR0FBekIsQ0FBOEJRLEVBQUQsS0FBUztBQUMvREMsTUFBQUEsRUFBRSxFQUFFRCxFQUFFLENBQUNDLEVBRHdEO0FBRS9EQyxNQUFBQSxVQUFVLEVBQUVGLEVBQUUsQ0FBQ0UsVUFBSCxHQUNSRixFQUFFLENBQUNFLFVBQUgsQ0FBY1YsR0FBZCxDQUFtQlcsQ0FBRCxJQUNoQnJCLDBCQUEwQixDQUFFcUIsQ0FBRixDQUQ1QixDQURRLEdBSVJqQixTQU4yRDtBQU8vRFMsTUFBQUEsSUFBSSxFQUFFWCxpQkFBaUIsQ0FBRWdCLEVBQUUsQ0FBQ0wsSUFBTDtBQVB3QyxLQUFULENBQTdCLENBQTNCO0FBU0Q7O0FBRURaLEVBQUFBLEtBQUssQ0FBQ3FCLFNBQU4sR0FBa0JqQyxpQkFBaUIsQ0FBRVksS0FBSyxDQUFDcUIsU0FBUixDQUFuQztBQUVBckIsRUFBQUEsS0FBSyxDQUFDc0IsSUFBTixDQUFXSixFQUFYLEdBQWdCOUIsaUJBQWlCLENBQUVZLEtBQUssQ0FBQ3NCLElBQU4sQ0FBV0osRUFBYixDQUFqQztBQUNBSyxFQUFBQSxXQUFXLENBQUN2QixLQUFELENBQVg7QUFDQSxTQUFPQSxLQUFQO0FBQ0Q7O0FBRUQsU0FBU3VCLFdBQVQsQ0FBcUJDLEdBQXJCLEVBQStCO0FBQzdCLFFBQU1DLE9BQU8sR0FBR0QsR0FBRyxZQUFZRSxLQUEvQjs7QUFDQSxPQUFLLE1BQU1DLENBQVgsSUFBZ0JILEdBQWhCLEVBQXFCO0FBQ25CLFFBQUlBLEdBQUcsQ0FBQ0csQ0FBRCxDQUFILEtBQVcsSUFBZixFQUFxQjtBQUNuQkYsTUFBQUEsT0FBTyxHQUFHRCxHQUFHLENBQUNJLE1BQUosQ0FBV0QsQ0FBWCxFQUFjLENBQWQsQ0FBSCxHQUFzQixPQUFPSCxHQUFHLENBQUNHLENBQUQsQ0FBdkM7QUFDRCxLQUZELE1BRU8sSUFBSSxPQUFPSCxHQUFHLENBQUNHLENBQUQsQ0FBVixLQUFrQixRQUF0QixFQUFnQztBQUNyQ0osTUFBQUEsV0FBVyxDQUFDQyxHQUFHLENBQUNHLENBQUQsQ0FBSixDQUFYO0FBQ0Q7QUFDRjtBQUNGOztBQUVELFNBQVNFLHVCQUFULENBQ0VDLFNBREYsRUFFRUMsVUFGRixFQUdFO0FBQ0FDLEVBQUFBLE1BQU0sQ0FBQ0MsaUJBQVAsQ0FDRWhELFNBREYsRUFFRSx5QkFGRixFQUdFNkMsU0FIRixFQUlFQyxVQUpGO0FBTUQ7O0FBRUR4QyxNQUFNLENBQUMyQyxrQkFBUCxHQUE0QjNDLE1BQU0sQ0FBQzJDLGtCQUFQLElBQTZCLEVBQXpEO0FBQ0EzQyxNQUFNLENBQUMyQyxrQkFBUCxDQUEwQkMsTUFBMUIsR0FBbUM1QyxNQUFNLENBQUMyQyxrQkFBUCxDQUEwQkMsTUFBMUIsSUFBb0MsRUFBdkU7QUFDQTVDLE1BQU0sQ0FBQzJDLGtCQUFQLENBQTBCQyxNQUExQixDQUFpQ0MsaUJBQWpDLEdBQ0U3QyxNQUFNLENBQUMyQyxrQkFBUCxDQUEwQkMsTUFBMUIsQ0FBaUNDLGlCQUFqQyxJQUFzRCxFQUR4RDtBQUVBN0MsTUFBTSxDQUFDMkMsa0JBQVAsQ0FBMEJDLE1BQTFCLENBQWlDQyxpQkFBakMsQ0FBbURDLG1CQUFuRCxHQUNFOUMsTUFBTSxDQUFDMkMsa0JBQVAsQ0FBMEJDLE1BQTFCLENBQWlDQyxpQkFBakMsQ0FBbURDLG1CQUFuRCxJQUEwRSxFQUQ1RTs7QUFHQTlDLE1BQU0sQ0FBQzJDLGtCQUFQLENBQTBCQyxNQUExQixDQUFpQ0MsaUJBQWpDLENBQW1ERSxlQUFuRCxHQUFxRSxPQUNuRVIsU0FEbUUsRUFFbkVTLE9BRm1FLEVBR25FQyxLQUhtRSxLQUloRTtBQUNILFFBQU1DLGFBQWEsR0FBR25DLHdDQUF3QyxDQUFDaUMsT0FBRCxDQUE5RDtBQUNBLFFBQU1SLFVBQVUsR0FBSSxNQUFPeEMsTUFBTSxDQUFDbUQsU0FBUCxDQUN4QkMsV0FEdUIsQ0FDY0MsTUFEZCxDQUNxQjtBQUM3Q0MsSUFBQUEsU0FBUyxFQUFFSjtBQURrQyxHQURyQixDQUExQjtBQUlBdkQsRUFBQUEsb0JBQW9CLENBQUM0RCxHQUFyQixDQUF5Qk4sS0FBekIsRUFBZ0NULFVBQWhDO0FBQ0FGLEVBQUFBLHVCQUF1QixDQUFDQyxTQUFELEVBQVlDLFVBQVosQ0FBdkI7QUFDRCxDQVpEOztBQWNBeEMsTUFBTSxDQUFDMkMsa0JBQVAsQ0FBMEJDLE1BQTFCLENBQWlDQyxpQkFBakMsQ0FBbURDLG1CQUFuRCxDQUF1RVUseUJBQXZFLEdBQ0VQLEtBRGlHLElBRTlGO0FBQ0gsUUFBTVQsVUFBVSxHQUFHN0Msb0JBQW9CLENBQUM4RCxHQUFyQixDQUF5QlIsS0FBekIsQ0FBbkI7O0FBQ0EsTUFBSVQsVUFBVSxLQUFLNUIsU0FBbkIsRUFBOEI7QUFDNUIsV0FBTyxJQUFQO0FBQ0Q7O0FBQ0QsU0FBTzRCLFVBQVUsQ0FBQ2tCLHlCQUFYLEVBQVA7QUFDRCxDQVJEIiwic291cmNlc0NvbnRlbnQiOlsi77u/ZGVjbGFyZSB2YXIgRG90TmV0OiBhbnk7XHJcblxyXG4vLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6IGludGVyZmFjZS1uYW1lXHJcbmludGVyZmFjZSBXaW5kb3cge1xyXG4gIEN1cnJpZVRlY2hub2xvZ2llczogYW55O1xyXG59XHJcblxyXG4vLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6IGludGVyZmFjZS1uYW1lXHJcbmludGVyZmFjZSBQdWJsaWNLZXlDcmVkZW50aWFsIHtcclxuICBnZXRDbGllbnRFeHRlbnNpb25SZXN1bHRzOiAoKSA9PiBBcnJheUJ1ZmZlcjtcclxufVxyXG5cclxuLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOiBpbnRlcmZhY2UtbmFtZVxyXG5pbnRlcmZhY2UgUHVibGljS2V5Q3JlZGVudGlhbFBhcmFtZXRlcnMge1xyXG4gIHR5cGU6IFwicHVibGljLWtleVwiIHwgXCJwYXNzd29yZFwiIHwgXCJmZWRlcmF0ZWRcIjtcclxufVxyXG5cclxuLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOiBpbnRlcmZhY2UtbmFtZVxyXG5pbnRlcmZhY2UgUHVibGljS2V5Q3JlZGVudGlhbERlc2NyaXB0b3Ige1xyXG4gIHR5cGU6IFwicHVibGljLWtleVwiIHwgXCJwYXNzd29yZFwiIHwgXCJmZWRlcmF0ZWRcIjtcclxufVxyXG5cclxuLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOiBpbnRlcmZhY2UtbmFtZVxyXG5pbnRlcmZhY2UgQXV0aGVudGljYXRvclNlbGVjdGlvbkNyaXRlcmlhIHtcclxuICB1c2VyVmVyaWZpY2F0aW9uOiBcInJlcXVpcmVkXCIgfCBcInByZWZlcnJlZFwiIHwgXCJkaXNjb3VyYWdlZFwiIHwgdW5kZWZpbmVkO1xyXG59XHJcblxyXG5jb25zdCBuYW1lc3BhY2U6IHN0cmluZyA9IFwiQ3VycmllVGVjaG5vbG9naWVzLkJsYXpvci5XZWJBdXRoZW50aWNhdGlvblwiO1xyXG5cclxuY29uc3QgcHVibGljS2V5Q3JlZGVudGlhbHM6IE1hcDxzdHJpbmcsIFB1YmxpY0tleUNyZWRlbnRpYWw+ID0gbmV3IE1hcDxcclxuICBzdHJpbmcsXHJcbiAgUHVibGljS2V5Q3JlZGVudGlhbFxyXG4+KCk7XHJcblxyXG5mdW5jdGlvbiBiYXNlNjRUb1VpbnRBcnJheShiYXNlNjQ6IHN0cmluZykge1xyXG4gIGNvbnN0IGJpbmFyeVN0cmluZyA9IHdpbmRvdy5hdG9iKGJhc2U2NCk7XHJcbiAgY29uc3QgbGVuID0gYmluYXJ5U3RyaW5nLmxlbmd0aDtcclxuICBjb25zdCBieXRlcyA9IG5ldyBVaW50OEFycmF5KGxlbik7XHJcbiAgZm9yIChsZXQgaSA9IDA7IGkgPCBsZW47IGkrKykge1xyXG4gICAgYnl0ZXNbaV0gPSBiaW5hcnlTdHJpbmcuY2hhckNvZGVBdChpKTtcclxuICB9XHJcbiAgcmV0dXJuIGJ5dGVzO1xyXG59XHJcblxyXG5mdW5jdGlvbiBnZXRDcmVkZW50aWFsVHJhbnNwb3J0VHlwZShpbnB1dDogbnVtYmVyKTogQXV0aGVudGljYXRvclRyYW5zcG9ydCB7XHJcbiAgc3dpdGNoIChpbnB1dCkge1xyXG4gICAgY2FzZSAwOlxyXG4gICAgZGVmYXVsdDpcclxuICAgICAgcmV0dXJuIFwidXNiXCI7XHJcbiAgICBjYXNlIDE6XHJcbiAgICAgIHJldHVybiBcIm5mY1wiO1xyXG4gICAgY2FzZSAyOlxyXG4gICAgICByZXR1cm4gXCJibGVcIjtcclxuICAgIGNhc2UgMzpcclxuICAgICAgcmV0dXJuIFwiaW50ZXJuYWxcIjtcclxuICB9XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGdldENyZWRlbnRpYWxUeXBlKFxyXG4gIGlucHV0OiBudW1iZXIsXHJcbik6IFwicHVibGljLWtleVwiIHwgXCJwYXNzd29yZFwiIHwgXCJmZWRlcmF0ZWRcIiB7XHJcbiAgc3dpdGNoIChpbnB1dCkge1xyXG4gICAgY2FzZSAwOlxyXG4gICAgZGVmYXVsdDpcclxuICAgICAgcmV0dXJuIFwicHVibGljLWtleVwiO1xyXG4gICAgY2FzZSAxOlxyXG4gICAgICByZXR1cm4gXCJwYXNzd29yZFwiO1xyXG4gICAgY2FzZSAyOlxyXG4gICAgICByZXR1cm4gXCJmZWRlcmF0ZWRcIjtcclxuICB9XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGdldFVzZXJWZXJpZmljYXRpb25UeXBlKFxyXG4gIGlucHV0OiBudW1iZXIsXHJcbik6IFwicmVxdWlyZWRcIiB8IFwicHJlZmVycmVkXCIgfCBcImRpc2NvdXJhZ2VkXCIgfCB1bmRlZmluZWQge1xyXG4gIGlmIChpbnB1dCA9PSBudWxsKSB7XHJcbiAgICByZXR1cm4gdW5kZWZpbmVkO1xyXG4gIH1cclxuXHJcbiAgc3dpdGNoIChpbnB1dCkge1xyXG4gICAgY2FzZSAwOlxyXG4gICAgZGVmYXVsdDpcclxuICAgICAgcmV0dXJuIFwicmVxdWlyZWRcIjtcclxuICAgIGNhc2UgMTpcclxuICAgICAgcmV0dXJuIFwicHJlZmVycmVkXCI7XHJcbiAgICBjYXNlIDI6XHJcbiAgICAgIHJldHVybiBcImRpc2NvdXJhZ2VkXCI7XHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiBnZXRBdXRoZW50aWNhdG9yQXR0YWNobWVudFR5cGUoXHJcbiAgaW5wdXQ6IG51bWJlcixcclxuKTogXCJwbGF0Zm9ybVwiIHwgXCJjcm9zcy1wbGF0Zm9ybVwiIHwgdW5kZWZpbmVkIHtcclxuICBpZiAoaW5wdXQgPT0gbnVsbCkge1xyXG4gICAgcmV0dXJuIHVuZGVmaW5lZDtcclxuICB9XHJcblxyXG4gIHN3aXRjaCAoaW5wdXQpIHtcclxuICAgIGNhc2UgMDpcclxuICAgIGRlZmF1bHQ6XHJcbiAgICAgIHJldHVybiBcInBsYXRmb3JtXCI7XHJcbiAgICBjYXNlIDE6XHJcbiAgICAgIHJldHVybiBcImNyb3NzLXBsYXRmb3JtXCI7XHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiBnZXRBdHRlc3RhdGlvblR5cGUoXHJcbiAgaW5wdXQ6IG51bWJlcixcclxuKTogXCJub25lXCIgfCBcImluZGlyZWN0XCIgfCBcImRpcmVjdFwiIHwgdW5kZWZpbmVkIHtcclxuICBpZiAoaW5wdXQgPT0gbnVsbCkge1xyXG4gICAgcmV0dXJuIHVuZGVmaW5lZDtcclxuICB9XHJcblxyXG4gIHN3aXRjaCAoaW5wdXQpIHtcclxuICAgIGNhc2UgMDpcclxuICAgIGRlZmF1bHQ6XHJcbiAgICAgIHJldHVybiBcIm5vbmVcIjtcclxuICAgIGNhc2UgMTpcclxuICAgICAgcmV0dXJuIFwiaW5kaXJlY3RcIjtcclxuICAgIGNhc2UgMjpcclxuICAgICAgcmV0dXJuIFwiZGlyZWN0XCI7XHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiBmb3JtYXRQdWJsaWNLZXlDcmVkZW50aWFsQ3JlYXRpb25PcHRpb25zKFxyXG4gIGlucHV0OiBQdWJsaWNLZXlDcmVkZW50aWFsQ3JlYXRpb25PcHRpb25zLFxyXG4pOiBQdWJsaWNLZXlDcmVkZW50aWFsQ3JlYXRpb25PcHRpb25zIHtcclxuICBpbnB1dC5hdHRlc3RhdGlvbiA9IGdldEF0dGVzdGF0aW9uVHlwZSgoaW5wdXQuYXR0ZXN0YXRpb24gYXMgYW55KSBhcyBudW1iZXIpO1xyXG4gIGlucHV0LnB1YktleUNyZWRQYXJhbXMgPSBpbnB1dC5wdWJLZXlDcmVkUGFyYW1zLm1hcCgocGtjcCkgPT4gKHtcclxuICAgIGFsZzogcGtjcC5hbGcsXHJcbiAgICB0eXBlOiBnZXRDcmVkZW50aWFsVHlwZSgocGtjcCBhcyBhbnkpIGFzIG51bWJlciksXHJcbiAgfSkpO1xyXG5cclxuICBpZiAoaW5wdXQuYXV0aGVudGljYXRvclNlbGVjdGlvbikge1xyXG4gICAgaW5wdXQuYXV0aGVudGljYXRvclNlbGVjdGlvbi5hdXRoZW50aWNhdG9yQXR0YWNobWVudCA9IGdldEF1dGhlbnRpY2F0b3JBdHRhY2htZW50VHlwZShcclxuICAgICAgKGlucHV0LmF1dGhlbnRpY2F0b3JTZWxlY3Rpb24uYXV0aGVudGljYXRvckF0dGFjaG1lbnQgYXMgYW55KSBhcyBudW1iZXIsXHJcbiAgICApO1xyXG5cclxuICAgIGlucHV0LmF1dGhlbnRpY2F0b3JTZWxlY3Rpb24udXNlclZlcmlmaWNhdGlvbiA9IGdldFVzZXJWZXJpZmljYXRpb25UeXBlKFxyXG4gICAgICAoaW5wdXQuYXV0aGVudGljYXRvclNlbGVjdGlvbi51c2VyVmVyaWZpY2F0aW9uIGFzIGFueSkgYXMgbnVtYmVyLFxyXG4gICAgKTtcclxuICB9XHJcblxyXG4gIGlmIChpbnB1dC5leGNsdWRlQ3JlZGVudGlhbHMpIHtcclxuICAgIGlucHV0LmV4Y2x1ZGVDcmVkZW50aWFscyA9IGlucHV0LmV4Y2x1ZGVDcmVkZW50aWFscy5tYXAoKGVjKSA9PiAoe1xyXG4gICAgICBpZDogZWMuaWQsXHJcbiAgICAgIHRyYW5zcG9ydHM6IGVjLnRyYW5zcG9ydHNcclxuICAgICAgICA/IGVjLnRyYW5zcG9ydHMubWFwKCh0KSA9PlxyXG4gICAgICAgICAgICBnZXRDcmVkZW50aWFsVHJhbnNwb3J0VHlwZSgodCBhcyBhbnkpIGFzIG51bWJlciksXHJcbiAgICAgICAgICApXHJcbiAgICAgICAgOiB1bmRlZmluZWQsXHJcbiAgICAgIHR5cGU6IGdldENyZWRlbnRpYWxUeXBlKChlYy50eXBlIGFzIGFueSkgYXMgbnVtYmVyKSxcclxuICAgIH0pKTtcclxuICB9XHJcblxyXG4gIGlucHV0LmNoYWxsZW5nZSA9IGJhc2U2NFRvVWludEFycmF5KChpbnB1dC5jaGFsbGVuZ2UgYXMgYW55KSBhcyBzdHJpbmcpO1xyXG5cclxuICBpbnB1dC51c2VyLmlkID0gYmFzZTY0VG9VaW50QXJyYXkoKGlucHV0LnVzZXIuaWQgYXMgYW55KSBhcyBzdHJpbmcpO1xyXG4gIHJlbW92ZU51bGxzKGlucHV0KTtcclxuICByZXR1cm4gaW5wdXQ7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHJlbW92ZU51bGxzKG9iajogYW55KSB7XHJcbiAgY29uc3QgaXNBcnJheSA9IG9iaiBpbnN0YW5jZW9mIEFycmF5O1xyXG4gIGZvciAoY29uc3QgayBpbiBvYmopIHtcclxuICAgIGlmIChvYmpba10gPT09IG51bGwpIHtcclxuICAgICAgaXNBcnJheSA/IG9iai5zcGxpY2UoaywgMSkgOiBkZWxldGUgb2JqW2tdO1xyXG4gICAgfSBlbHNlIGlmICh0eXBlb2Ygb2JqW2tdID09PSBcIm9iamVjdFwiKSB7XHJcbiAgICAgIHJlbW92ZU51bGxzKG9ialtrXSk7XHJcbiAgICB9XHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiBjb21wbGV0ZUNyZWF0ZVB1YmxpY0tleShcclxuICByZXF1ZXN0SWQ6IHN0cmluZyxcclxuICBjcmVkZW50aWFsOiBQdWJsaWNLZXlDcmVkZW50aWFsLFxyXG4pIHtcclxuICBEb3ROZXQuaW52b2tlTWV0aG9kQXN5bmMoXHJcbiAgICBuYW1lc3BhY2UsXHJcbiAgICBcIkNvbXBsZXRlQ3JlYXRlUHVibGljS2V5XCIsXHJcbiAgICByZXF1ZXN0SWQsXHJcbiAgICBjcmVkZW50aWFsLFxyXG4gICk7XHJcbn1cclxuXHJcbndpbmRvdy5DdXJyaWVUZWNobm9sb2dpZXMgPSB3aW5kb3cuQ3VycmllVGVjaG5vbG9naWVzIHx8IHt9O1xyXG53aW5kb3cuQ3VycmllVGVjaG5vbG9naWVzLkJsYXpvciA9IHdpbmRvdy5DdXJyaWVUZWNobm9sb2dpZXMuQmxhem9yIHx8IHt9O1xyXG53aW5kb3cuQ3VycmllVGVjaG5vbG9naWVzLkJsYXpvci5XZWJBdXRoZW50aWNhdGlvbiA9XHJcbiAgd2luZG93LkN1cnJpZVRlY2hub2xvZ2llcy5CbGF6b3IuV2ViQXV0aGVudGljYXRpb24gfHwge307XHJcbndpbmRvdy5DdXJyaWVUZWNobm9sb2dpZXMuQmxhem9yLldlYkF1dGhlbnRpY2F0aW9uLlB1YmxpY0tleUNyZWRlbnRpYWwgPVxyXG4gIHdpbmRvdy5DdXJyaWVUZWNobm9sb2dpZXMuQmxhem9yLldlYkF1dGhlbnRpY2F0aW9uLlB1YmxpY0tleUNyZWRlbnRpYWwgfHwge307XHJcblxyXG53aW5kb3cuQ3VycmllVGVjaG5vbG9naWVzLkJsYXpvci5XZWJBdXRoZW50aWNhdGlvbi5DcmVhdGVQdWJsaWNLZXkgPSBhc3luYyAoXHJcbiAgcmVxdWVzdElkOiBzdHJpbmcsXHJcbiAgb3B0aW9uczogUHVibGljS2V5Q3JlZGVudGlhbENyZWF0aW9uT3B0aW9ucyxcclxuICBkb21JZDogc3RyaW5nLFxyXG4pID0+IHtcclxuICBjb25zdCBiZXR0ZXJPcHRpb25zID0gZm9ybWF0UHVibGljS2V5Q3JlZGVudGlhbENyZWF0aW9uT3B0aW9ucyhvcHRpb25zKTtcclxuICBjb25zdCBjcmVkZW50aWFsID0gKGF3YWl0ICh3aW5kb3cubmF2aWdhdG9yXHJcbiAgICAuY3JlZGVudGlhbHMgYXMgQ3JlZGVudGlhbHNDb250YWluZXIpLmNyZWF0ZSh7XHJcbiAgICBwdWJsaWNLZXk6IGJldHRlck9wdGlvbnMsXHJcbiAgfSkpIGFzIFB1YmxpY0tleUNyZWRlbnRpYWw7XHJcbiAgcHVibGljS2V5Q3JlZGVudGlhbHMuc2V0KGRvbUlkLCBjcmVkZW50aWFsKTtcclxuICBjb21wbGV0ZUNyZWF0ZVB1YmxpY0tleShyZXF1ZXN0SWQsIGNyZWRlbnRpYWwpO1xyXG59O1xyXG5cclxud2luZG93LkN1cnJpZVRlY2hub2xvZ2llcy5CbGF6b3IuV2ViQXV0aGVudGljYXRpb24uUHVibGljS2V5Q3JlZGVudGlhbC5HZXRDbGllbnRFeHRlbnNpb25SZXN1bHRzID0gKFxyXG4gIGRvbUlkOiBzdHJpbmcsXHJcbikgPT4ge1xyXG4gIGNvbnN0IGNyZWRlbnRpYWwgPSBwdWJsaWNLZXlDcmVkZW50aWFscy5nZXQoZG9tSWQpO1xyXG4gIGlmIChjcmVkZW50aWFsID09PSB1bmRlZmluZWQpIHtcclxuICAgIHJldHVybiBudWxsO1xyXG4gIH1cclxuICByZXR1cm4gY3JlZGVudGlhbC5nZXRDbGllbnRFeHRlbnNpb25SZXN1bHRzKCk7XHJcbn07XHJcbiJdfQ==
