import { Injectable } from '@angular/core'

@Injectable()
export class Configuration {

    public static GetApiUrl() {
        return 'https://localhost:7284/';     
    }

    public static apiUrl = Configuration.GetApiUrl()

}