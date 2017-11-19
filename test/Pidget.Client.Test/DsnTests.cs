using System;
using System.Collections.Generic;
using Xunit;

namespace Pidget.Client.Test
{
    public class DsnTests
    {
        public const string PublicKey = "public_key";

        public const string SecretKey = "secret_key";

        public const string Host = "host";

        public const string ProjectId = "project_id";

        public const string Path = "/path/";

        public static readonly Dsn SentryDsn = Dsn.Create(
            $"https://{PublicKey}:{SecretKey}@{Host}{Path}{ProjectId}");

        [Fact]
        public void GetPublicKey()
            => Assert.Equal(PublicKey, SentryDsn.GetPublicKey());

        [Fact]
        public void GetPrivateKey()
            => Assert.Equal(SecretKey, SentryDsn.GetSecretKey());

        [Fact]
        public void GetPath()
            => Assert.Equal(Path, SentryDsn.GetPath());

        [Fact]
        public void GetProjectId()
            => Assert.Equal(ProjectId, SentryDsn.GetProjectId());

        [Fact]
        public void ToString_ReturnsUriString()
            => Assert.Equal(SentryDsn.Uri.ToString(), SentryDsn.ToString());

        [Fact]
        public void GetCaptureUrl()
            => Assert.Equal(
                expected: $"https://{Host}/api/{ProjectId}/store/",
                actual: SentryDsn.GetCaptureUrl());

    }
}
