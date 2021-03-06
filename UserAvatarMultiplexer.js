import axios from "axios";

let pendingIds = [];
let promise = null;

export function getAvatarById(id) {
  pendingIds.push(id);
  if (!promise) {
    promise = new Promise((resolve, reject) =>
      setTimeout(function() {
        axios
          .post("/api/users/multiplexed-avatar", {
            ids: pendingIds
          })
          .then(resolve, reject);
        promise = null;
        pendingIds = [];
      }, 0)
    );
  }
  return promise.then(resp => resp.data.item[id]);
}
