import React from 'react';
import ContentLoader from "react-content-loader"
const Skeleton = () => {
    return (
        <div>
            <ContentLoader
                speed={2}
                width={1300}
                height={460}
                viewBox="0 0 1300 460"
                backgroundColor="#f3f3f3"
                foregroundColor="#ecebeb"
            >
                <rect x="-10" y="-4" rx="2" ry="2" width="1340" height="421" />
            </ContentLoader>
        </div>
    );
};

export default Skeleton;