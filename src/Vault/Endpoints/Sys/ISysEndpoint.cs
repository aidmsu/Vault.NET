﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vault.Models;

namespace Vault.Endpoints.Sys
{
    public interface ISysEndpoint
    {
        Task<VaultResponse<Dictionary<string, MountInfo>>> ListMounts(CancellationToken ct = default(CancellationToken));
        Task Mount(string path, MountInfo mountInfo, CancellationToken ct = default(CancellationToken));
        Task Unmount(string path, CancellationToken ct = default(CancellationToken));
        Task Remount(string from, string to, CancellationToken ct = default(CancellationToken));
        Task TuneMount(string path, MountConfig mountConfig, CancellationToken ct = default(CancellationToken));
        Task<MountConfig> MountConfig(string path, CancellationToken ct = default(CancellationToken));

        Task<LeaderResponse> Leader(CancellationToken ct = default(CancellationToken));

        Task<GenerateRootStatusResponse> GenerateRootStatus(CancellationToken ct = default(CancellationToken));
        Task<GenerateRootStatusResponse> GenerateRootInit(string otp, string pgpKey, CancellationToken ct = default(CancellationToken));
        Task GenerateRootCancel(CancellationToken ct = default(CancellationToken));
        Task<GenerateRootStatusResponse> GenerateRootUpdate(string shard, string nonce, CancellationToken ct = default(CancellationToken));

        Task<bool> InitStatus(CancellationToken ct = default(CancellationToken));
        Task<InitResponse> Init(InitRequest request, CancellationToken ct = default(CancellationToken));

        Task<SealStatusResponse> SealStatus(CancellationToken ct = default(CancellationToken));
        Task Seal(CancellationToken ct = default(CancellationToken));
        Task<SealStatusResponse> Unseal(string shard, CancellationToken ct = default(CancellationToken));
        Task<SealStatusResponse> ResetUnsealProcess(CancellationToken ct = default(CancellationToken));

        Task<VaultResponse<TData>> Renew<TData>(string leaseId, CancellationToken ct = default(CancellationToken));
        Task<VaultResponse<TData>> Renew<TData>(string leaseId, int increment, CancellationToken ct = default(CancellationToken));
        Task Revoke(string id, CancellationToken ct = default(CancellationToken));
        Task RevokeForce(string id, CancellationToken ct = default(CancellationToken));
        Task RevokePrefix(string id, CancellationToken ct = default(CancellationToken));

        Task<List<string>> Capabilities(string token, string path, CancellationToken ct = default(CancellationToken));
        Task<List<string>> CapabilitiesSelf(string path, CancellationToken ct = default(CancellationToken));

        Task Rotate(CancellationToken ct = default(CancellationToken));
        Task<KeyStatus> KeyStatus(CancellationToken ct = default(CancellationToken));

        Task<string> AuditHash(string path, string input, CancellationToken ct = default(CancellationToken));
        Task<Dictionary<string, Audit>> ListAudit(CancellationToken ct = default(CancellationToken));
        Task EnableAudit(string path, string auditType, string description, Dictionary<string, string> options, CancellationToken ct = default(CancellationToken));
        Task DisableAudit(string path, CancellationToken ct = default(CancellationToken));

        Task<List<string>> ListPolicies(CancellationToken ct = default(CancellationToken));
        Task<string> GetPolicy(string name, CancellationToken ct = default(CancellationToken));
        Task PutPolicy(string name, string rules, CancellationToken ct = default(CancellationToken));
        Task DeletePolicy(string name, CancellationToken ct = default(CancellationToken));

        Task StepDown(CancellationToken ct = default(CancellationToken));

        Task<Dictionary<string, AuthMount>> ListAuth(CancellationToken ct = default(CancellationToken));
        Task EnableAuth(string path, string authType, string description, CancellationToken ct = default(CancellationToken));
        Task DisableAuth(string path, CancellationToken ct = default(CancellationToken));

        Task<WrappingLookupResponse> WrapLookup(string token, CancellationToken ct = default(CancellationToken));
        Task<SecretWrapInfo> Rewrap(string token, CancellationToken ct = default(CancellationToken));
        Task<T> Unwrap<T>(string token, CancellationToken ct = default(CancellationToken));
        Task<SecretWrapInfo> Wrap<T>(T content, CancellationToken ct = default(CancellationToken));
    }
}
