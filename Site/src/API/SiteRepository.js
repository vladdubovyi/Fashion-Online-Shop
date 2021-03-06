import axios from "axios";
import APIConfig from "../Config/APIConfig";

export default class SiteRepository {
  static async GetSlides() {
    try {
      const response = await axios.get(APIConfig.Path + "slider");
      return response.data;
    } catch (ex) {
      return null;
    }
  }
  static async GetCollections() {
    try {
      const response = await axios.get(APIConfig.Path + "collection");
      return response.data;
    } catch (ex) {
      return null;
    }
  }
}
