using configs;
using System.Collections.Generic;

namespace dtos
{
    public class Permissions
    {
        private List<Permission> acl;

        public Permissions()
        {
            this.LoadPermissions();
            this.DisableAllPermissions();

            this.SetACLMode(FeaturesUnlocked.FREE);
        }

        private void LoadPermissions()
        {
            this.acl = new List<Permission>();
            // for each permission defined in the constants
            acl.Add(new Permission() { name = PermissionsList.SAVE_XPTS, authority = false, message = "Unable to produce XPT Pattern file." });
            acl.Add(new Permission() { name = PermissionsList.SAVE_SCALE, authority = false, message = "Unable to save scale file." });
            acl.Add(new Permission() { name = PermissionsList.CONVERT_SCALES, authority = false, message = "Unable to convert scales." });
        }

        public void DisableAllPermissions()
        {
            foreach (Permission p in this.acl)
            {
                p.authority = false;
            }
        }

        public void SetACLMode(int mode)
        {
            switch (mode)
            {
                case FeaturesUnlocked.DEMO:
                    this.DisableAllPermissions();
                    this.Disallow(PermissionsList.SAVE_XPTS);
                    this.Disallow(PermissionsList.SAVE_SCALE);
                    this.Disallow(PermissionsList.CONVERT_SCALES);
                    break;
                case FeaturesUnlocked.FREE:
                    this.Allow(PermissionsList.SAVE_XPTS);
                    this.Allow(PermissionsList.SAVE_SCALE);
                    this.Allow(PermissionsList.CONVERT_SCALES);
                    break;
                case FeaturesUnlocked.PREMIUM:
                    // enable all permissions
                    foreach (Permission p in this.acl)
                    {
                        p.authority = true;
                    }
                    break;
                default:
                    this.DisableAllPermissions();
                    break;
            }
        }

        private void Allow(string name)
        {
            foreach (Permission p in this.acl)
            {
                if (p.name == name)
                {
                    p.authority = true;
                }
            }
        }

        private void Disallow(string name)
        {
            foreach (Permission p in this.acl)
            {
                if (p.name == name)
                {
                    p.authority = false;
                }
            }
        }

        public bool HasAuthority(string name)
        {
            bool authority = false;

            foreach (Permission p in this.acl)
            {
                if (p.name == name)
                {
                    authority = p.authority;
                }
            }

            return authority;
        }
    }
}
