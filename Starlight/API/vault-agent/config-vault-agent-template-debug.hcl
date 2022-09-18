pid_file = "/vault/API/vault-agent/pidfile"

vault {
  address = "http://vault:8200"
}

auto_auth {
  method {
    type = "approle"
    config = {
      role_id_file_path                   = "/vault/API/vault-agent/role-id"
      secret_id_file_path                 = "/vault/API/vault-agent/secret-id"
      remove_secret_id_file_after_reading = false
    }
  }

  sink {
    type = "file"

    config = {
      path = "/vault/API/vault-agent/token"
    }
  }
}

template {
  source      = "/vault/API/vault-agent/appsettings-debug.ctmpl"
  destination = "/vault/API/vault/secrets/appsettings.json"
}