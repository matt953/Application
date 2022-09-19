pid_file = "/vault/API/vault-agent/pidfile"

vault {
  address = "http://vault:8200"
}

auto_auth {
  method {
    type = "approle"
    config = {
      role_id_file_path                   = "/vault/API/vault-agent/role-id-migrations"
      secret_id_file_path                 = "/vault/API/vault-agent/secret-id-migrations"
      remove_secret_id_file_after_reading = false
    }
  }

  sink {
    type = "file"

    config = {
      path = "/vault/API/vault-agent/token-migrations"
    }
  }
}

template {
  source      = "/vault/API/vault-agent/appsettings-migration.ctmpl"
  destination = "/vault/API/vault/secrets/appsettings.migration.json"
}